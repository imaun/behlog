using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Behlog.Core;
using Behlog.Core.Security;
using Behlog.Core.Extensions;
using Microsoft.Extensions.Logging;
using Behlog.Web.Core.Settings;

namespace Behlog.Web.Common.Controllers {

    /// <summary>
    /// Base Controller class for Behlog front controllers.
    /// Use it for End-user Website's controllers.
    /// </summary>
    public abstract class BehlogController: Controller {

        private readonly IWebsiteInfo _websiteInfo;
        private readonly IUserContext _userContext;
        private readonly IOptionsSnapshot<BehlogSetting> _setting;
        private readonly ILogger<Controller> _logger;

        protected BehlogController(IWebsiteInfo websiteInfo,
            IUserContext userContext,
            IOptionsSnapshot<BehlogSetting> setting,
            ILogger<Controller> logger
        ) {
            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;

            userContext.CheckArgumentIsNull(nameof(userContext));
            _userContext = userContext;

            setting.CheckArgumentIsNull(nameof(setting));
            _setting = setting;

            logger.CheckArgumentIsNull(nameof(logger));
            _logger = logger;
        }

        public BehlogSetting Options => _setting.Value;

        public IWebsiteInfo WebsiteInfo => _websiteInfo;

        public IUserContext UserInfo => _userContext;
    }
}
