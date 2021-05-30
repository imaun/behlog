using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Behlog.Web.Components.Content
{
    public class TeamViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(
            string viewName = "") {

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(viewName)
                    );

            return await Task.FromResult(View());
        }
    }
}
