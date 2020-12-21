using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.System {
    public class WebsiteOption {

        public WebsiteOption() {
        }

        #region Properties

        public int Id { get; set; }
        public int WebsiteId { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Category { get; set; }
        public int OrderNum { get; set; }
        public EntityStatus Status { get; set; }
        public string Description { get; set; }
        public int? LangId { get; set; }

        #endregion

        #region Navigations

        public Website Website { get; set; }
        public Language Language { get; set; }

        #endregion
    }

    public static class WebsiteOptionCategoryNames {
        public const string SocialNetwork = "social-network";
        public const string ContactInfo = "contact-info";
        public const string General = "general";
    }
}
