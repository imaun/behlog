using System.Collections.Generic;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.System {
    
    public class Tag {
        public Tag() {
            PostTags = new HashSet<PostTag>();
        }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
        public int WebsiteId { get; set; }
        #endregion

        #region Navigations
        public ICollection<PostTag> PostTags { get; set; }
        public Website Website { get; set; }
        #endregion

    }
}
