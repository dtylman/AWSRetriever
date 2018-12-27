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

        public string ResultText()
        {
            string message = String.Format("{0} {1} {2}: ", operation.Name, operation.ServiceName, operation.Region.DisplayName);
            if (IsError())
            {
                message += string.Format("Error: {0}", this.ex.Message);
            } else
            {
                message += string.Format("{0} items retrieved", this.operation.CollectedObjects.Count);
            }
            return message;
        }

        public Operation Operation { get => operation; set => operation = value; }

        public Exception Ex => ex;

        public int Progress { get; internal set; }

        public bool IsError()
        {
            return this.ex != null;
        }
    }
}