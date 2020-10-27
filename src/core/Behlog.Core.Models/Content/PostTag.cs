using Behlog.Core.Models.System;

namespace Behlog.Core.Models.Content {
    
    public class PostTag {
        public PostTag() {

        }

        #region Properties
        public int PostId { get; set; }
        public int TagId { get; set; }
        #endregion

        #region Navigations
        public Post Post { get; set; }
        public Tag Tag { get; set; }
        #endregion
    }
}
