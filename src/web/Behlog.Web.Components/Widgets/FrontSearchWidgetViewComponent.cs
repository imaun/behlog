using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Behlog.Web.Components.Widgets {
    
    public class FrontSearchWidgetViewComponent: ViewComponent {

        public async Task<IViewComponentResult> InvokeAsync() {

            return await Task.FromResult(
                    View()
                );
        }

    }
}
