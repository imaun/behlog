using System.Collections.Generic;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.System {
    
    public class PostType {
        public PostType() {
            Categories = new HashSet<Category>();
            Posts = new HashSet<Post>();
        }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public EntityStatus Status { get; set; }
        #endregion

        #region Navigations
        public ICollection<Category> Categories { get; set; }
        public ICollection<Post> Posts { get; set; }

        #endregion

        #region Consts

        public const string PAGE = "page";
        public const string BLOG = "blog";
        public const string PRODUCT = "product";
        public const string SERVICE = "service";
        public const string GALLERY = "gallery";
        public const string ARTICLE = "article";
        public const string NEWS = "news";

        #endregion

    }
}

