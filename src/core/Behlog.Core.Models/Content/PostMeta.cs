using Behlog.Core.Models.Base;
using Behlog.Core.Models.System;

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

        #endregion

        #region Navigations
        public Post Post { get; set; }
        public Language Language { get; set; }
        #endregion
    }
}
