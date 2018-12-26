using System;
using System.Threading;
using Amazon;
using Amazon.Runtime;

namespace CloudOps
{
    public class OperationInvokation
    {
        private readonly Operation operation;
        private readonly RegionEndpoint region;
        private readonly AWSCredentials creds;
        private readonly int pageSize;

        public OperationInvokation(Operation op, RegionEndpoint region, AWSCredentials creds, int pageSize)
        {
            this.operation = op;
            this.region = region;
            this.creds = creds;
            this.pageSize = pageSize;   
        }
        
        public InvokationResult Invoke(CancellationToken token)
        {
            this.operation.CancellationToken = token;
            this.operation.Region = region;
            try
            {
                this.operation.Invoke(this.creds, this.region, this.pageSize);
                return new InvokationResult(this.operation);
            }
            catch (Exception ex)
            {
                return new InvokationResult(ex, this.operation);
            }
            
        }
    }
}