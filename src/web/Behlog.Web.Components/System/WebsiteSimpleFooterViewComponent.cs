using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Services.Contracts.System;
using Behlog.Web.ViewModels.System;
using Mapster;


namespace Behlog.Web.Components.System {

    [ViewComponent]
    public class WebsiteSimpleFooterViewComponent: ViewComponent
    {
        private readonly IWebsiteOptionService _websiteOptionService;

        public WebsiteSimpleFooterViewComponent(IWebsiteOptionService websiteOptionService) {
            websiteOptionService.CheckArgumentIsNull(nameof(websiteOptionService));
            _websiteOptionService = websiteOptionService;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var model = new WebsiteFooterViewModel();
        }
    }
}
