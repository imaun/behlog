using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Behlog.Services.Security;
using Behlog.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Behlog.Web.Admin.Controllers
{
    [Area(AreaNames.AdminArea)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [Route("[area]/[controller]/[action]")]
    public class HomeController : Controller
    {

        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public IActionResult Index()
        {
            return View();
        }
    }
}