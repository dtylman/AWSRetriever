using System;

namespace CloudOps
{
    public class InvokationResult
    {
        private Operation operation;
        private readonly Exception ex;

        public InvokationResult(Operation operation)
        {
            this.Operation = operation;
        }

        public InvokationResult(Exception ex, Operation operation)
        {
            this.Operation = operation;
            this.ex = ex;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.operation.Name, this.ex);
        }
        public Operation Operation { get => operation; set => operation = value; }

        public Exception Ex => ex;

        
    }
}