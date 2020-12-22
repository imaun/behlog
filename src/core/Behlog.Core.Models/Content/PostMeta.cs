using Behlog.Core.Models.Base;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.Content {
    
    public class PostMeta: HasMetaData {
        public PostMeta() {
        }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public string Category { get; set; }
        public int? LangId { get; set; }
        public int PostId { get; set; }
        public string IconName { get; set; }
        public string CoverPhoto { get; set; }
        public EntityStatus Status { get; set; }
        public int OrderNumber { get; set; }
        #endregion

        #region Navigations
        public Post Post { get; set; }
        public Language Language { get; set; }
        #endregion
    }
}
