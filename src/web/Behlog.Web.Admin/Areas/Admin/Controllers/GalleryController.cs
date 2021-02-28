using Behlog.Services.Security;
using Behlog.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.Admin.Controllers {

    [Area(AreaNames.AdminArea)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [Route("[area]/[controller]")]
    public class GalleryController : Controller {

        
    }
}
