using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Services.Dto.System;

namespace Behlog.Services.Contracts.System
{
    public interface IWebsiteOptionService {
        Task<WebsiteContactInfoDto> GetContactInfoAsync(int? langId = null);
        Task<WebsiteSocialNetworkDto> GetSocialNetworksAsync();
        Task<WebsiteOptionResultDto> CreateOrUpdateAsync(CreateWebsiteOptionDto model);
        Task CreateOrUpdateOptionsAsync(WebsiteOptionCategoryDto model);
        Task CreateContactOptionsAsync();
        Task CreateSocialNetworksOptionsAsync();
    }
}
