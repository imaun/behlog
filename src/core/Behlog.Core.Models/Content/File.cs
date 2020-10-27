using System.Collections.Generic;
using Behlog.Core.Models.Base;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;

namespace Behlog.Core.Models.Content {
    
    public class File: HasMetaData {

        public File() {
            PostFiles = new HashSet<PostFile>();
        }

        #region Properties
        public long Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public PostFileType FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public FileStatus Status { get; set; }
        public int WebsiteId { get; set; }

        #endregion

        #region Navigations
        public Website Website { get; set; }
        public ICollection<PostFile> PostFiles { get; set; }
        #endregion

    }

}
