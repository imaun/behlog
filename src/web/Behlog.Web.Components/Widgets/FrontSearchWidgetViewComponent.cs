using Behlog.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Behlog.Web.Components.Widgets {
    
    public class FrontSearchWidgetViewComponent: ViewComponent {

        public async Task<IViewComponentResult> InvokeAsync(
            string viewName = "") {

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(viewName)
                    );

            return await Task.FromResult(
                    View()
                );
        }

    }
}
