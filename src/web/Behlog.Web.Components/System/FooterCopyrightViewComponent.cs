using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Web.ViewModels.System;
using Microsoft.AspNetCore.Mvc;

namespace Behlog.Web.Components.System {
    public class FooterCopyrightViewComponent: ViewComponent {
        
        public async Task<IViewComponentResult> InvokeAsync(
            string viewName = "") {

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(viewName)
                    );

            var model = new WebsiteFooterCopyrightViewModel();
            return await Task.FromResult(
                View(model)
                );
        }
    }
}