using System;
using Amazon;
using CloudOps;

namespace Retriever.Model
{
    public class ProgressMessage
    {
        private string result;
        private int imageIndex;
        private DateTime time;
        private string operation;
        private string service;
        private string regionSystemName;
        private string regionDisplayName;

        public ProgressMessage()
        {

        }

        public ProgressMessage(InvokationResult ir)
        {
            this.time = ir.Time;
            this.operation = ir.Operation.Name;
            this.service = ir.Operation.ServiceName;
            this.regionSystemName = ir.Operation.Region.SystemName;
            this.regionDisplayName = ir.Operation.Region.DisplayName;
            if (ir.IsError())
            {
                this.result = ir.Ex.Message;
                this.imageIndex = 2;
            }
            else
            {
                this.result = ir.ResultText();
                this.imageIndex = 0;                
            }
        }

        public string Result { get => result; set => result = value; }
        public int ImageIndex { get => imageIndex; set => imageIndex = value; }
        public string Operation { get => operation; set => operation = value; }
        public string Service { get => service; set => service = value; }
        
        public DateTime Time { get => time; set => time = value; }
        public string RegionSystemName { get => regionSystemName; set => regionSystemName = value; }
        public string Region { get => regionDisplayName; set => regionDisplayName = value; }
    }
}