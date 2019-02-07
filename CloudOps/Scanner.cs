using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace CloudOps
{
    public class Scanner
    {
        private readonly ConcurrentQueue<Operation> invokations = new ConcurrentQueue<Operation>();
        private readonly ScannerProgress progress = new ScannerProgress();        
        private CancellationTokenSource cancellation;
        private int maxTasks = 10;
        private readonly ConcurrentBag<CloudObject> collectedObjects = new ConcurrentBag<CloudObject>();
        private readonly List<Task> tasks = new List<Task>();        

        public ConcurrentQueue<Operation> Invokations => invokations;

        public int MaxTasks { get => maxTasks; set => maxTasks = value; }
        //in milliseconds
        public int TimeOut { get; set; } = 1000 * 60 * 60;
        public ScannerProgress Progress { get => progress;  }

        // true if scanner is running
        public bool Running
        {
            get
            {
                return this.tasks.Count > 0;
            }
        }        

        void Queue(Operation operation)
        {
            this.Invokations.Enqueue(operation);
        }

        public void Cancel()
        {
            while (!this.invokations.IsEmpty)
            {
                this.invokations.TryDequeue(out Operation op);
            }
            if (this.cancellation != null)
            {
                this.cancellation.Cancel();
            }
        }

        public void Scan()
        {
            if (this.tasks.Count > 0)
            {
                throw new ApplicationException("Scan already running");
            }
            while (!this.collectedObjects.IsEmpty) //clean items!
            {
                collectedObjects.TryTake(out CloudObject obj);
            }
            try
            {
                this.progress.Total = this.invokations.Count;
                this.cancellation = new CancellationTokenSource();
                try
                {
                    for (int i = 0; i < this.MaxTasks; i++)
                    {
                        this.tasks.Add(StartScanning());
                    }
                }
                finally
                {
                    Task.WaitAll(tasks.ToArray(), this.TimeOut, this.cancellation.Token);
                    if (this.progress != null)
                    {
                        this.progress.ReportDone();
                    }
                }
            }
            finally
            {
                this.tasks.Clear();
            }                                    
        }

        private Task StartScanning()
        {            
            return Task.Factory.StartNew(() =>
            {
                this.cancellation.Token.ThrowIfCancellationRequested();
                while (!this.invokations.IsEmpty)
                {
                    if (this.cancellation.Token.IsCancellationRequested)
                    {
                        this.cancellation.Token.ThrowIfCancellationRequested();
                    }

                    if (invokations.TryDequeue(out Operation invokation))
                    {
                        OperationResult result = invokation.Invoke(this.cancellation.Token);                        
                        ReportProgress(result);
                    }
                }                
            }, this.cancellation.Token);
        }
        

        private void ReportProgress(OperationResult result)
        {
            if (this.progress != null)
            {
                this.progress.Report(this.invokations.Count, result);
            }
        }
    }
}
