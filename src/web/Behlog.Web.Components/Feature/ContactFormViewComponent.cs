using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Services.Contracts.System;
using Behlog.Web.ViewModels.Feature;
using Mapster;

namespace Behlog.Web.Components.Feature {

    public class ContactFormViewComponent: ViewComponent {

        private readonly IWebsiteOptionService _websiteOptionService;

        public ContactFormViewComponent(
            IWebsiteOptionService websiteOptionService) {
            websiteOptionService.CheckArgumentIsNull(nameof(websiteOptionService));
            _websiteOptionService = websiteOptionService;
        }


        public async Task<IViewComponentResult> InvokeAsync(
            string actionUrl = "",
            string formTitle = "",
            string formDescription = "",
            string coverImageUrl = "",
            bool withContactInfo = false,
            bool withSocialNetworks = false,
            string viewName = null) {

            var model = new CreateContactViewModel {
                WidgetTitle = formTitle,
                WidgetDescription = formDescription,
                WidgetCoverImageUrl = coverImageUrl,
                WidgetActionUrl = actionUrl
            };

            if(withContactInfo) {
                var contactInfo = await _websiteOptionService.GetContactInfoAsync();
                if (contactInfo != null)
                    model.ContactInfo = contactInfo.Adapt<WebsiteContactInfoViewModel>();
            }

            if(withSocialNetworks) {
                var socialNetworks = await _websiteOptionService.GetSocialNetworksAsync();
                if (socialNetworks != null)
                    model.SocialNetworks = socialNetworks.Adapt<WebsiteSocialNetworksViewModel>();
            }

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
