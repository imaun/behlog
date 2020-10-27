using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Services.Dto.System;

namespace Behlog.Services.Contracts.System
{
    public interface IWebsiteService {
        Task<WebsiteInfo> GetWebsiteInfo(int websiteId);
        Task<WebsiteResultDto> CreateAsync(WebsiteCreateDto model);
        Task<bool> IsThereAnyWebsiteAsync();
    }
}
