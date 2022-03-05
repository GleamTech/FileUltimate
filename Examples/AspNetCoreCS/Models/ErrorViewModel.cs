using System;

namespace GleamTech.FileUltimateExamples.AspNetCoreCS.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
