using System.Collections.Generic;
using Behlog.Web.ViewModels.Content;
using Behlog.Web.ViewModels.Feature;

namespace Behlog.Web.ViewModels.System {
    public class WebsiteFooterViewModel {
        public WebsiteFooterViewModel() {
            Posts = new List<PostItemViewModel>();
            SocialNetworks = new WebsiteSocialNetworksViewModel();
            Subscriber = new SubscriberViewModel();
        }

        public int WebsiteId { get; set;}
        public string CopyrightText { get; set; }
        public IEnumerable<PostItemViewModel> Posts { get; set; }
        public WebsiteSocialNetworksViewModel SocialNetworks { get; set; }
        public SubscriberViewModel Subscriber { get; set; }
    }

    public class WebsiteFooterCopyrightViewModel {
        public WebsiteFooterCopyrightViewModel() {
            SocialNetworks = new WebsiteSocialNetworksViewModel();
        }
        
        public string Text { get; set; }
        public WebsiteSocialNetworksViewModel SocialNetworks { get; set; }

    }

}

