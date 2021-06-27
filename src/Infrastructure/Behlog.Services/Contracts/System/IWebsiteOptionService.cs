using System.Threading.Tasks;
using Behlog.Services.Dto.System;

namespace Behlog.Services.Contracts.System {

    public interface IWebsiteOptionService {

        Task<WebsiteOptionResultDto> GetOptionAsync(string optionKey);

        Task<WebsiteOptionResultDto> GetOptionAsync(
            string optionKey,
            string lang,
            bool enabled = true);

        WebsiteContactInfoDto GetContactInfo(int? langId);

        Task<WebsiteContactInfoDto> GetContactInfoAsync(int? langId = null);

        Task<WebsiteContactInfoDto> GetContactInfoAsync(string langKey);

        Task<WebsiteSocialNetworkDto> GetSocialNetworksAsync();

        Task<WebsiteOptionResultDto> CreateOrUpdateAsync(CreateWebsiteOptionDto model);

        Task CreateOrUpdateOptionsAsync(WebsiteOptionCategoryDto model);

        Task CreateContactOptionsAsync();

        Task CreateSocialNetworksOptionsAsync();

    }
}
