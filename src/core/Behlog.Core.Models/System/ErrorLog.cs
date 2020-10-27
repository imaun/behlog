using System;

namespace Behlog.Core.Models.System {
    public class ErrorLog {
        
        public ErrorLog() {

        }

        #region Properties

        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int? WebsiteId { get; set; }
        public string Ip { get; set; }
        public string RequestUrl { get; set; }
        public string UserAgent { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public int StatusCode { get; set; }
        public string SessionId { get; set; }
        public string Description { get; set; }

        #endregion

        #region Navigations
        public Website Website { get; set; }

        #endregion
    }
}
