using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.System {
    public class Menu {
        public Menu() { }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Parameters { get; set; }
        public EntityStatus Status { get; set; }
        public int WebsiteId { get; set; }
        public int LangId { get; set; }
        public string RouteName { get; set; }
        public int OrderNumber { get; set; }
        public string CssClass { get; set; }
        public string CssStyle { get; set; }
        public string Target { get; set; }
        #endregion

        #region Navigations

        public Website Website { get; set; }
        public Language Language { get; set; }

        #endregion
    }

    public static class MenuRouteName {

        public const string Default = "default";
        public const string PostDetaitlById = "postDetailById";
        public const string PostDetail = "postDetail";
        public const string PostIndex = "postIndex";
        public const string Gallery = "gallery";

        public const string PostIndexByLang = "postIndexByLang";
        public const string PostDetailByLang = "postDetailByLang";
        public const string GalleryByLang = "galleryByLang";

        public const string DefaultEn = "defaultEn";
        public const string PostIndexEn = "postIndexEn";
        public const string PostDetailEn = "postDetailEn";
        public const string GalleryEn = "galleryEn";
    }
}
