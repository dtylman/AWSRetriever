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
        private readonly ConcurrentQueue<OperationInvokation> invokations = new ConcurrentQueue<OperationInvokation>();
        private readonly ScannerProgress progress = new ScannerProgress();        
        private CancellationTokenSource cancellation;
        private int maxTasks = 10;
        private readonly ConcurrentBag<CloudObject> collectedObjects = new ConcurrentBag<CloudObject>();
        private readonly List<Task> tasks = new List<Task>();
        

        public ConcurrentQueue<OperationInvokation> Invokations => invokations;

        public int MaxTasks { get => maxTasks; set => maxTasks = value; }
        //in milliseconds
        public int TimeOut { get; set; } = 1000 * 60 * 60;
        public ScannerProgress Progress { get => progress;  }

        public ConcurrentBag<CloudObject> CollectedObjects => collectedObjects;

        void Queue(OperationInvokation operation)
        {
            this.Invokations.Enqueue(operation);
        }

        public void Cancel()
        {
            while (!this.invokations.IsEmpty)
            {
                OperationInvokation op;
                this.invokations.TryDequeue(out op);
            }
            this.cancellation.Cancel();
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

                    if (invokations.TryDequeue(out OperationInvokation invokation))
                    {
                        InvokationResult result = invokation.Invoke(this.cancellation.Token);
                        foreach (CloudObject cloudObject in result.Operation.CollectedObjects)
                        {
                            this.CollectedObjects.Add(cloudObject);
                        }
                        ReportProgress(result);
                    }
                }                
            }, this.cancellation.Token);
        }
        

        private void ReportProgress(InvokationResult result)
        {
            if (this.progress != null)
            {
                this.progress.Report(this.invokations.Count, result);
            }
        }
    }
}
