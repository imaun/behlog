using System;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.Feature {
    
    public class Contact {
        public Contact() {

        }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
        public DateTime SentDate { get; set; }
        public int WebsiteId { get; set; }
        public ContactMessageStatus? Status { get; set; }
        public DateTime? ReadDate { get; set; }
        #endregion

        #region Navigations
        public Website Website { get; set; }
        #endregion

    }
}

