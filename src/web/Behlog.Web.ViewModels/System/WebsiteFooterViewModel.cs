using System.Collections.Generic;
using Behlog.Web.ViewModels.Content;
using Behlog.Web.ViewModels.Feature;

namespace Behlog.Web.ViewModels.System {
    public class WebsiteFooterViewModel {

        public WebsiteFooterViewModel() {
            Posts = new List<PostItemViewModel>();
            SocialNetworks = new WebsiteSocialNetworksViewModel();
            Subscriber = new SubscriberViewModel();
            Links = new List<LinkViewModel>();
            LinkCategories = new List<LinkCategoryViewModel>();
        }

        public int WebsiteId { get; set;}
        public string CopyrightText { get; set; }
        public string AboutText { get; set; }
        public string AboutUrl { get; set; }
        public WebsiteContactInfoViewModel ContactInfo { get; set; }
        public IEnumerable<PostItemViewModel> Posts { get; set; }
        public IEnumerable<LinkViewModel> Links { get; set; }
        public IEnumerable<LinkCategoryViewModel> LinkCategories { get; set; }
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

