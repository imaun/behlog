using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DNTCommon.Web.Core;
using Behlog.Core.Extensions;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Models.Enum;
using Behlog.Services.Contracts.Security;
using Behlog.Web.Common;
using Behlog.Resources.Strings;
using Behlog.Web.Core.Settings;
using Behlog.Web.Admin.ViewModels.Identity;
using Behlog.Core;

namespace Behlog.Web.Identity.Controllers
{
    [Area(AreaNames.IdentityArea)]
    [AllowAnonymous]
    public class LoginController : Controller {
        
        private readonly ILogger<LoginController> _logger;
        private readonly IAppSignInManager _signInManager;
        private readonly IAppUserManager _userManager;
        private readonly IOptionsSnapshot<BehlogSetting> _appSettings;
        private readonly IDateService _dateService;
        private readonly IWebsiteInfo _websiteInfo;

        public const string _RET_URL = "returnUrl";

        public LoginController(
            ILogger<LoginController> logger,
            IAppSignInManager signInManager,
            IAppUserManager userManager,
            IOptionsSnapshot<BehlogSetting> appSettings,
            IDateService dateService,
            IWebsiteInfo websiteInfo
        ) {
            logger.CheckArgumentIsNull();
            signInManager.CheckArgumentIsNull();
            userManager.CheckArgumentIsNull();
            appSettings.CheckArgumentIsNull();
            dateService.CheckArgumentIsNull();
            websiteInfo.CheckArgumentIsNull();

            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings;
            _dateService = dateService;
            _websiteInfo = websiteInfo;
        }


        [HttpGet("[area]/[controller]"), NoBrowserCache]
        public IActionResult Index(string returnUrl = null) 
        {
            ViewData[_RET_URL] = returnUrl;
            return View();
        }

        [HttpPost("[area]/[controller]"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl = null) {
            ViewData[_RET_URL] = returnUrl;

            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByNameAsync(model.Username);
            if(user == null)
            {
                ModelState.AddModelError("", AppErrorText.LoginInvallidUserPass);
                return View(model);
            }

            if(user.Status != UserStatus.Enabled) {
                ModelState.AddModelError("", AppErrorText.LoginUserDisabled);
                return View(model);
            }

            if(_appSettings.Value.EnableEmailConfirmation &&
               !await _userManager.IsEmailConfirmedAsync(user)) 
            {
                ModelState.AddModelError("", AppErrorText.LoginEmailNotVerified);
                return View(model);
            }
            
            var result = await _signInManager.PasswordSignInAsync(model.Username,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: true);

            await _userManager.AddClaimAsync(user, new Claim(
                    "WebsiteId", _websiteInfo.Id.ToString()
                ));

            if(result.Succeeded) {
                _logger.LogInformation($"{model.Username} logged in on ${_dateService.UtcNow()}");

                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction(
                    "Index",
                    "Home",
                    new { area = AreaNames.AdminArea }
                );
            }

            if(result.RequiresTwoFactor) {

            }

            if(result.IsLockedOut) {
                _logger.LogWarning($"{model.Username} is locked-out.");
                ModelState.AddModelError("", AppErrorText.LoginLockedOut);
                return View(model);
            }

            if(result.IsNotAllowed) {
                ModelState.AddModelError("", AppErrorText.LoginIsNotAllowed);
                return View(model);
            }

            ModelState.AddModelError(string.Empty, AppErrorText.LoginNotValid);

            return View(model);
        }
    }
}