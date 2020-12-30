using System.Collections.Generic;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.Shop;

namespace Behlog.Core.Models.System {

    public class Language {

        public const string KEY_fa_IR = "fa";
        public const string KEY_en_US = "en";

        public Language() {
            Categories = new HashSet<Category>();
            Posts = new HashSet<Post>();
            PostMeta = new HashSet<PostMeta>();
            ProductMeta = new HashSet<ProductMeta>();
            UserMeta = new HashSet<UserMeta>();
            Websites = new HashSet<Website>();
            Options = new HashSet<WebsiteOption>();
            Sections = new HashSet<Section>();
        }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string LangKey { get; set; }
        public EntityStatus Status { get; set; }


        #endregion

        #region Navigations
        public ICollection<Category> Categories { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostMeta> PostMeta { get; set; }
        public ICollection<ProductMeta> ProductMeta { get; set; }
        public ICollection<UserMeta> UserMeta { get; set; }
        public ICollection<Website> Websites { get; set; }
        public ICollection<Menu> MenuItems { get; set; }
        public ICollection<WebsiteOption> Options { get; set; }
        public ICollection<Section> Sections { get; set; }
        #endregion

    }
}
