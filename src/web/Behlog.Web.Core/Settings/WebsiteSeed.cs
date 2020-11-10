namespace Behlog.Web.Core.Settings {

    public class WebsiteSeed {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Url { get; set; }
        public WebsiteOptionSetting Options { get; set; }
    }
}
