using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Models.System;

namespace Behlog.Core.Contracts.Repository.System
{
    public interface ICategoryRepository: IBaseRepository<Category, int> {
        Task<IEnumerable<Category>> FindChildrenAsync(int? parentId);

        Task<IEnumerable<Category>> GetEnabledByPostTypeAndLangAsync(
            int postTypeId, 
            int langId);

        Task<IEnumerable<Category>> GetEnabledByPostTypeAndLangAsync(
            string postTypeSlug,
            string langKey = Language.KEY_fa_IR);
    }
}
