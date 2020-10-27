using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Extensions;
using Behlog.Core.Models.System;
using Behlog.Services.Dto.System;
using Behlog.Core.Contracts.Services.Common;
using Mapster;
using Behlog.Factories.Contracts.System;

namespace Behlog.Factories.System
{
    public class ErrorLogFactory: IErrorLogFactory {

        private readonly IDateService _dateService;
        private readonly IWebsiteInfo _websiteInfo;

        public ErrorLogFactory(
            IDateService dateService,
            IWebsiteInfo websiteInfo
        ) {
            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;
        }

        public async Task<ErrorLog> MakeAsync(CreateErrorLogDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var result = model.Adapt<ErrorLog>();
            result.WebsiteId = _websiteInfo.Id;
            result.Ip = AppHttpContext.Current
                .Connection
                .RemoteIpAddress?.ToString();
            result.UserAgent = AppHttpContext.Request.Headers["User-Agent"][0];
            result.SessionId = AppHttpContext.Current.Session.Id;
            result.CreateDate = _dateService.UtcNow();
            result.Exception = model.Exception.GetBaseException().Message;
            result.StackTrace = model.Exception.GetBaseException()
                .StackTrace
                .Substring(0, 3000);
            
            return await Task.FromResult(result);
        }
    }
}
