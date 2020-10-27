using System;
using System.Collections.Generic;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.System {
    
    public class Layout {

        public const string DEF_LayoutName = "DefaultFa";

        public Layout() {
            Posts = new HashSet<Post>();
            Websites = new HashSet<Website>();
        }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorWebUrl { get; set; }
        public string Path { get; set; }
        public int OrderNumber { get; set; }
        public EntityStatus Status { get; set; }
        public bool IsRtl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        #endregion

        #region Navigations
        public ICollection<Post> Posts { get; set; }
        public ICollection<Website> Websites { get; set; }
        #endregion

    }
}
