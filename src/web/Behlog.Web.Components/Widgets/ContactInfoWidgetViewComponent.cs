using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Web.ViewModels.Feature;
using Behlog.Services.Contracts.System;
using Mapster;

namespace Behlog.Web.Components.Widgets {

    public class ContactInfoWidgetViewComponent: ViewComponent {

        private readonly IWebsiteOptionService _optionService;

        public ContactInfoWidgetViewComponent(IWebsiteOptionService optionService) {
            optionService.CheckArgumentIsNull(nameof(optionService));
            _optionService = optionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string description = "",
            string viewName = null) {
            var contactInfo = await _optionService
                .GetContactInfoAsync();

            var model = new ContactInfoWidgetViewModel {
                Address = contactInfo.Address1,
                Email = contactInfo.Email,
                Phones = contactInfo.Phones,
                Description = description
            };

            var socialNetworks = await _optionService.GetSocialNetworksAsync();
            if (socialNetworks != null)
                model.SocialNetworks = socialNetworks.Adapt<WebsiteSocialNetworksViewModel>();

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
