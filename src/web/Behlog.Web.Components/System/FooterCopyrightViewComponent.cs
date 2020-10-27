using System.Threading.Tasks;
using Behlog.Web.ViewModels.System;
using Microsoft.AspNetCore.Mvc;

namespace Behlog.Web.Components.System {
    public class FooterCopyrightViewComponent: ViewComponent {
        
        public async Task<IViewComponentResult> InvokeAsync() {
            var model = new WebsiteFooterCopyrightViewModel();
            return await Task.FromResult(
                View(model)
                );
        }
    }
}