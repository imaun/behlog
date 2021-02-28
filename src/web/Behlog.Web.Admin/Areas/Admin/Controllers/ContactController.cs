using System;
using System.Collections.Generic;
using System.Linq;
using Mapster;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Behlog.Core.Extensions;
using Behlog.Web.Common;
using Behlog.Services.Security;
using Behlog.Services.Contracts.Feature;
using Behlog.Services.Dto.Admin.Feature;
using Behlog.Web.Admin.ViewModels.Feature;

namespace Behlog.Web.Admin.Controllers {

    [Area(AreaNames.AdminArea)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [Route("[area]/[controller]")]
    public class ContactController : Controller {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService) {
            contactService.CheckArgumentIsNull(nameof(contactService));
            _contactService = contactService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1) {
            var filter = new AdminContactIndexFilter {
                PageSize = 10,
                PageIndex = page - 1
            };
            var result = await _contactService.GetAdminIndexAsync(filter);

            var model = result.Adapt<AdminContactIndexViewModel>();

            model.Filter.PageIndex = filter.PageIndex;
            model.Filter.PageSize = filter.PageSize;

            return await Task.FromResult(
                View(model)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminContactIndexViewModel model) {
            var filter = new AdminContactIndexFilter {
                Email = model.Filter.Email,
                Name = model.Filter.Name,
                PageIndex = model.Filter.PageIndex,
                PageSize = model.Filter.PageSize
            };

            var result = await _contactService.GetAdminIndexAsync(filter);

            model = result.Adapt<AdminContactIndexViewModel>();
            model.DataSource.HasFilter = true;

            return View(model);
        }
    }
}
