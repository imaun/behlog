using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Services.Dto.System;
using Behlog.Services.Dto.Core;
using Behlog.Core.Models.System;

namespace Behlog.Services.Contracts.System
{
    public interface ICategoryService {
        Task<int> CreateAsync(CategoryCreateDto model);

        Task UpdateAsync(CategoryEditDto model);

        Task<CategoryResultDto> FindAsync(int id);

        Task<CategoryResultDto> GetResultAsync(int id);

        Task<DataGridDto<CategoryGridItemDto>> GetGridDataAsync(
            int postTypeId, 
            CategoryGridOptions options);

        Task<IEnumerable<CategoryItemDto>> GetAvailableItemsAsync(
            int postTypeId, 
            int languageId);

        Task<IEnumerable<CategoryItemDto>> GetPostTypeCategoriesAsync(
            string postTypeSlug,
            string langKey = Language.KEY_fa_IR);
    }
}
