using System.Linq;
using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Extensions;
using Behlog.Services.Contracts.System;
using Behlog.Services.Dto.System;
using Mapster;

namespace Behlog.Services.System {

    public class MenuService: IMenuService {

        private readonly IWebsiteInfo _websiteInfo;
        private readonly IMenuRepository _menuRepository;
        private readonly IWebsiteOptionRepository _websiteOptionRepository;

        public MenuService(
            IWebsiteInfo websiteInfo,
            IMenuRepository menuRepository,
            IWebsiteOptionRepository websiteOptionRepository) {
            menuRepository.CheckArgumentIsNull(nameof(menuRepository));
            _menuRepository = menuRepository;

            websiteOptionRepository.CheckArgumentIsNull(nameof(websiteOptionRepository));
            _websiteOptionRepository = websiteOptionRepository;

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;
        }

        public async Task<WebsiteMenuDto> GetWebsiteMenuAsync(string lang = null)
            => await getWebsiteMenuAsync(_websiteInfo.Id, lang);

        private async Task<WebsiteMenuDto> getWebsiteMenuAsync(int websiteId, string lang = null) {
            var result = new WebsiteMenuDto {
                Items = (await _menuRepository
                    .GetEnabledByWebsiteAsync(websiteId, lang))
                        .OrderBy(_ => _.OrderNumber)
                        .ThenBy(_ => _.Id)
                        .ToList()
                        .Select(_ => _.Adapt<MenuItemDto>())
                        .ToList()
            };

            var logoOption = await _websiteOptionRepository
                .GetByKeyAsync(_websiteInfo.Id, "website.logo");

            if (logoOption != null)
                result.LogoPath = logoOption.Value;

            result.WebsiteTitle = _websiteInfo.Title;
            return await Task.FromResult(result);
        }
    }
}
