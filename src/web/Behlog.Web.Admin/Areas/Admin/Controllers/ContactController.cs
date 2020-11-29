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

namespace Behlog.Web.Admin.Areas.Admin.Controllers {

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
        public async Task<IActionResult> Index() {
            var result = await _contactService.GetAdminIndexAsync(new AdminContactIndexFilter {
                PageSize = 10,
                PageIndex = 0
            });

            var model = result.Adapt<AdminContactIndexViewModel>();

            return await Task.FromResult(
                View(model)
            );
        }
    }
}
