using System;

namespace Behlog.Services.Dto.System
{
    public class CreateErrorLogDto
    {
        public string RequestUrl { get; set; }
        public Exception Exception { get; set; }
        public int StatusCode { get; set; }
        public string Description { get; set; }
    }
}
