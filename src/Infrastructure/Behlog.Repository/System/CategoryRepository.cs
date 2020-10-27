using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;

namespace Behlog.Repository.System
{
    public class CategoryRepository: BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IBehlogContext context) : base(context) {
        }

        public async Task<IEnumerable<Category>> FindChildrenAsync(int? parentId) 
            => await _dbSet
                .Where(_ => _.ParentId == parentId)
                .ToListAsync();

        public async Task<IEnumerable<Category>> GetEnabledByPostTypeAndLangAsync(
            int postTypeId,
            int langId) {
            var result = await _dbSet
                .Where(_ => _.Status == EntityStatus.Enabled)
                .Where(_ => _.PostTypeId == postTypeId)
                .Where(_ => _.LangId == langId)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Category>> GetEnabledByPostTypeAndLangAsync(
            string postTypeSlug,
            string langKey = Language.KEY_fa_IR) {

            var result = await _dbSet
                .Where(_ => _.Status == EntityStatus.Enabled)
                .Where(_ => _.PostType.Slug.ToLower() == postTypeSlug.ToLower())
                .Where(_ => _.Language.LangKey == langKey)
                .ToListAsync();

            return result;
        }
    }
}
