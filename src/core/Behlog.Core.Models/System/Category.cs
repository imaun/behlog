using System.Collections.Generic;
using Behlog.Core.Models.Base;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Shop;

namespace Behlog.Core.Models.System {
    
    public class Category: HasMetaData {

        public Category() {
            Posts = new HashSet<Post>();
            Links = new HashSet<Link>();
            Products = new HashSet<Product>();
        }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int PostTypeId { get; set; }
        public int? ParentId { get; set; }
        public int LangId { get; set; }
        public string TreePath { get; set; }
        public int WebsiteId { get; set; }
        public EntityStatus Status { get; set; }
        #endregion

        #region Navigations
        public Website Website { get; set; }
        public PostType PostType { get; set; }
        public Language Language { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Link> Links { get; set; }
        public ICollection<Product> Products { get; set; }
        #endregion

    }
}
