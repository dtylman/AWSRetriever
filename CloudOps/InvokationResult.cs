using System;

namespace CloudOps
{
    public class InvokationResult
    {
        private Operation operation;
        private Exception ex;
        private DateTime time;
        private int progress;

        public Operation Operation { get => operation; set => operation = value; }
        public Exception Ex { get => ex; set => ex = value; }
        public DateTime Time { get => time; set => time = value; }
        public int Progress { get => progress; set => progress = value; }

        public InvokationResult()
        {

        }

        public InvokationResult(Operation operation)
        {
            this.operation = operation;
            this.time = DateTime.Now;
        }

        public InvokationResult(Exception ex, Operation operation)
        {
            this.operation = operation;
            this.ex = ex;
            this.time = DateTime.Now;
        }

        public string ResultText()
        {            
            if (IsError())
            {
                return string.Format("Error: {0}", this.ex.Message);
            } else
            {
                return string.Format("{0} items retrieved", this.operation.CollectedObjects.Count);
            }            
        }    

        public bool IsError()
        {
            return this.ex != null;
        }
    }
}