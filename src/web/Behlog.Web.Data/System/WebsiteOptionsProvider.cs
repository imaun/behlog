using Behlog.Core.Extensions;
using Behlog.Services.Contracts.System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Behlog.Web.ViewModels.System;
using Mapster;

namespace Behlog.Web.Data.System
{
    public class WebsiteOptionsProvider {

        private readonly IWebsiteOptionService _websiteOptionService;

        public WebsiteOptionsProvider(IWebsiteOptionService websiteOptionService) {
            websiteOptionService.CheckArgumentIsNull(nameof(websiteOptionService));
            _websiteOptionService = websiteOptionService;
        }

        private async Task<WebsiteOptionViewModel> getOptionAsync(string optionKey) {
            try {
                var option = await _websiteOptionService.GetOptionAsync(optionKey);
                return option.Adapt<WebsiteOptionViewModel>();
            }
            catch {
                return null;
            }
        }

        public async Task<WebsiteOptionViewModel> GetWebsiteLogoOptionAsync()
            => await getOptionAsync("website.logo");

        public async Task<WebsiteOptionViewModel> GetWebsiteFavIconAsync()
            => await getOptionAsync("website.favicon");
    }
}
