using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Behlog.Web.Components.Content
{
    public class TeamViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() {

            return await Task.FromResult(View());
        }
    }
}
