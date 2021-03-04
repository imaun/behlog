using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Behlog.Web.ViewModels.Feature;
using Behlog.Core.Extensions;

namespace Behlog.Web.Components.Feature {

    public class CallToActionViewComponent : ViewComponent {

        public async Task<IViewComponentResult> InvokeAsync(
            string title, 
            string actionUrl, 
            string description,
            string viewName = null) {

            var model = new CallToActionViewModel {
                ActionUrl = actionUrl,
                Title = title,
                Description = description
            };

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(model)
                );

            return await Task.FromResult(
                View(model)
            );
        }

    }

}
