using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Feature;
using Behlog.Factories.Contracts.Feature;
using Behlog.Core.Contracts.Services.Common;

namespace Behlog.Factories.Feature
{
    public class WebsiteVisitFactory : IWebsiteVisitFactory
    {
        private readonly IDateService _dateService;
        private readonly IWebsiteInfo _websiteInfo;

        public WebsiteVisitFactory(IDateService dateService,
            IWebsiteInfo websiteInfo) {
            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;
        }


        public async Task<WebsiteVisit> MakeAsync() {
            var entity = new WebsiteVisit {
                AbseloutUrl = AppHttpContext.AbsoluteUrl,
                CreateDate = _dateService.UtcNow(),
                IP = AppHttpContext.IpAddress,
                OsPlatform = AppHttpContext.OsPlatform,
                UserAgent = AppHttpContext.UserAgent,
                UrlReferrer = AppHttpContext.UrlReferer,
                SessionId = AppHttpContext.SessionId,
                WebsiteId = _websiteInfo.Id
            };

            return await Task.FromResult(entity);
        }

    }
}
