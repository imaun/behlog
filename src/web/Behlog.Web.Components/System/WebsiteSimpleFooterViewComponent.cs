using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Services.Contracts.System;
using Behlog.Web.ViewModels.System;
using Mapster;
using Behlog.Web.ViewModels.Feature;

namespace Behlog.Web.Components.System {

    [ViewComponent]
    public class WebsiteSimpleFooterViewComponent : ViewComponent
    {
        private readonly IWebsiteOptionService _websiteOptionService;

        public WebsiteSimpleFooterViewComponent(IWebsiteOptionService websiteOptionService) {
            websiteOptionService.CheckArgumentIsNull(nameof(websiteOptionService));
            _websiteOptionService = websiteOptionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            int? categoryId = null,
            string viewName = "") {

            var model = new WebsiteFooterViewModel();

            if (categoryId.HasValue) {

            }
            else {

            }

            model.Subscriber = new SubscriberViewModel();

            var socialNetworks = await _websiteOptionService
                .GetSocialNetworksAsync();

            if (socialNetworks != null)
                model.SocialNetworks = socialNetworks
                    .Adapt<WebsiteSocialNetworksViewModel>();

            var contactInfo = await _websiteOptionService.GetContactInfoAsync();
            if (contactInfo != null)
                model.ContactInfo = contactInfo.Adapt<WebsiteContactInfoViewModel>();

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(viewName, model)
                    );

            return await Task.FromResult(
                View(model)
                );
        }
        
    }
}
