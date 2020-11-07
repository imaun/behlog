using System.Linq;
using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Extensions;
using Behlog.Services.Contracts.System;
using Behlog.Services.Dto.System;
using Mapster;

namespace Behlog.Services.System
{
    public class MenuService: IMenuService {

        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository) {
            menuRepository.CheckArgumentIsNull(nameof(menuRepository));
            _menuRepository = menuRepository;
        }

        public async Task<WebsiteMenuDto> GetWebsiteMenuAsync(int websiteId) {
            var result = new WebsiteMenuDto {
                Items = (await _menuRepository.GetEnabledByWebsiteAsync(websiteId))
                    .OrderBy(_=> _.OrderNumber)
                    .ToList()
                    .Select(_ => _.Adapt<MenuItemDto>())
                    .ToList()
            };

            return await Task.FromResult(result);
        }
    }
}
