using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Web.ViewModels.Feature;
using Behlog.Services.Contracts.System;
using Mapster;

namespace Behlog.Web.Components.Widgets {

    public class SocialNetworkWidgetViewComponent: ViewComponent {

        private readonly IWebsiteOptionService _websiteOptionService;

        public SocialNetworkWidgetViewComponent(
            IWebsiteOptionService websiteOptionService) {
            websiteOptionService.CheckArgumentIsNull(nameof(websiteOptionService));
            _websiteOptionService = websiteOptionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string title,
            string viewName = null) {

            var socialNetworks = await _websiteOptionService.GetSocialNetworksAsync();
            var model = new WebsiteSocialNetworksViewModel();
            if (socialNetworks != null)
                model = socialNetworks.Adapt<WebsiteSocialNetworksViewModel>();
            else {
                model.Facebook = model.Instagram = model.LinkedIn
                    = model.Telegram = model.Twitter = model.Whatsapp
                    = model.YouTube = "#";
            }

            ViewData["widget-title"] = title;

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
