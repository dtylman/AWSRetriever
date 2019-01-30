using System;

namespace CloudOps
{
    public class ScannerProgress : Progress<InvokationResult>
    {
        // happens then the scanner had finished
        public event EventHandler Done;
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

        internal void ReportDone()
        {
            if (this.Done != null)
            {
                this.Done.Invoke(this, new EventArgs());
            }
        }
    }
}