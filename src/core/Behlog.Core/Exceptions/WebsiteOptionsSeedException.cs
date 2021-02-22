namespace Behlog.Core.Exceptions {

    public class WebsiteOptionsSeedException: BehlogException {
        public WebsiteOptionsSeedException() 
            : base(message: "WebsiteOptionsSeedInfo not present in appsetting.json file.") 
            { }
    }
}
