using System;

namespace CloudOps
{
    public class ScannerProgress : Progress<InvokationResult>
    {
        internal void Report(InvokationResult result)
        {
            OnReport(result);
        }
        
    }
}