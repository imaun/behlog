using Behlog.Core.Extensions;
using Behlog.Core.Security;
using Behlog.Web.Admin.ViewModels.Components;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Behlog.Web.Admin.Components
{
    [ViewComponent(Name = "AdminHeadNav")]
    public class AdminHeadNavViewComponent : ViewComponent
    {

        private readonly IUserContext _userContext;

        public AdminHeadNavViewComponent(IUserContext userContext) {
            userContext.CheckArgumentIsNull();
            _userContext = userContext;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var model = new AdminHeadNavModel {
                UserTitle = _userContext.UserTitle
            };
            return View(await Task.FromResult(model));
        }
    }
}
