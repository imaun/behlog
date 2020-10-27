using Behlog.Core.Models.Base;
using Behlog.Core.Models.System;

namespace Behlog.Core.Models.Feature {
    
    public class WebsiteVisit: VisitBaseData {
        public WebsiteVisit() {

        }

        #region Properties
        public long Id { get; set; }
        public int WebsiteId { get; set; }

        #endregion

        #region Navigations
        public Website Website { get; set; }
        
        #endregion

    }
}
