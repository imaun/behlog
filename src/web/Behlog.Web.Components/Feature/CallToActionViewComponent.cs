using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Behlog.Web.ViewModels.Feature;

namespace Behlog.Web.Components.Feature {
    public class CallToActionViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(
            string title, 
            string actionUrl, 
            string description) {

            var model = new CallToActionViewModel {
                ActionUrl = actionUrl,
                Title = title,
                Description = description
            };

            return await Task.FromResult(
                View(model)
                );
        }

    }

}
