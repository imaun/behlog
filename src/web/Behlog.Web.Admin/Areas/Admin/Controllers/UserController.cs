using Mapster;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Web.Common;
using Behlog.Services.Dto.Admin.Security;
using Behlog.Services.Security;
using Behlog.Services.Contracts.Security;
using Behlog.Web.Admin.ViewModels.Security;

namespace Behlog.Web.Admin.Controllers {

    [Area(AreaNames.AdminArea)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [Route("[area]/[controller]")]
    public class UserController : Controller {

        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            userService.CheckArgumentIsNull(nameof(userService));
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1) {
            var filter = new AdminUserIndexFilter {
                PageIndex = page-1,
                PageSize = 10
            };

            var result = await _userService.GetAdminIndexAsyc(filter);

            var model = result.Adapt<AdminUserIndexViewModel>();

            model.Filter.PageIndex = filter.PageIndex;
            model.Filter.PageSize = filter.PageSize;

            return await Task.FromResult(
                View(model)
                );
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminUserIndexViewModel model) {
            var filter = new AdminUserIndexFilter {
                Email = model.Filter.Email,
                PageIndex = model.Filter.PageIndex,
                PageSize = model.Filter.PageSize,
                PhoneNumber = model.Filter.PhoneNumber,
                Status = model.Filter.Status,
                Title = model.Filter.Title,
                UserName = model.Filter.UserName
            };

            var result = await _userService.GetAdminIndexAsyc(filter);

            var index = result.Adapt<AdminUserIndexViewModel>();
            index.DataSource.HasFilter = true;

            foreach (var user in index.DataSource.Items)
                user.Checked = true;

            return await Task.FromResult(
                View(index)
                );
        }

        [HttpGet]
        public async Task<IActionResult> New() {

            return View();
        }

        
    }
}
