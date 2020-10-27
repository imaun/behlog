using System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;

namespace Behlog.Core.Models.Feature {

    public class Subscriber {

        public Subscriber() { }

        #region Properties
        public long Id { get; set; }
        public int WebsiteId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public SubscriberStatus Status { get; set; }
        #endregion

        #region Navigations
        public Website Website { get; set; }

        #endregion
    }
}
