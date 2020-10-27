using Behlog.Core.Models.Base;
using Behlog.Core.Models.Content;

namespace Behlog.Core.Models.Feature {
    
    public class PostVisit: VisitBaseData {
        public PostVisit() {

        }

        #region Properties
        public long Id { get; set; }
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        #endregion

        #region Navigations
        public Post Post { get; set; }

        #endregion

    }
}
