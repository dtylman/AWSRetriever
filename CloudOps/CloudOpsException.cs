using System;
using System.Runtime.Serialization;

namespace CloudOps
{
    [Serializable]
    internal class CloudOpsException : Exception
    {
        public CloudOpsException()
        {
        }

        public CloudOpsException(string message) : base(message)
        {
        }

        public CloudOpsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CloudOpsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}