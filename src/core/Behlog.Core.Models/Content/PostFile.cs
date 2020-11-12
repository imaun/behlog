using Behlog.Core.Models.Base;

namespace Behlog.Core.Models.Content {
    public class PostFile: HasMetaData {

        public PostFile() {

        }

        #region Properties
        public long Id { get; set; }
        public int PostId { get; set; }
        public long FileId { get; set; }
        public int OrderNum { get; set; }
        public string Title { get; set; }
        public long? RelatedFileId { get; set; }
        #endregion

        #region Navigations

        public Post Post { get; set; }
        public File File { get; set; }

        #endregion
    }
}
