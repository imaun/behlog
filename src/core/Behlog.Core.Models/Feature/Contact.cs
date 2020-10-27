using System;
using Behlog.Core.Models.System;

namespace Behlog.Core.Models.Feature {
    
    public class Contact {
        public Contact() {

        }

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
        public DateTime SentDate { get; set; }
        public int WebsiteId { get; set; }
        #endregion

        #region Navigations
        public Website Website { get; set; }
        #endregion

    }
}

