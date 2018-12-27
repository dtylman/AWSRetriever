using System;

namespace CloudOps
{
    public class ScannerProgress : Progress<InvokationResult>
    {
        public int Total { get; internal set; }

        public void Report(int queueLen, InvokationResult result)
        {
            int percent = 0;
            if (this.Total > 0)
            {
                percent = ((this.Total - queueLen) * 100) / this.Total;
            }
            result.Progress = percent;
            OnReport(result);
        }
        
    }
}