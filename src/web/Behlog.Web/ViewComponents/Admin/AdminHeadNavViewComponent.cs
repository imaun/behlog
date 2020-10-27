using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Core.Security;
using Behlog.Web.ViewModels.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace Behlog.Web.ViewComponents.Admin
{
    [ViewComponent(Name = "AdminHeadNav")]
    public class AdminHeadNavViewComponent: ViewComponent {

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
