using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Microsoft.EntityFrameworkCore;

namespace Behlog.Repository.System
{
    public class MenuRepository: BaseRepository<Menu, int>, IMenuRepository
    {
        public MenuRepository(IBehlogContext context) : base(context) {
        }

        public async Task<IEnumerable<Menu>> GetByWebsiteAsync(int websiteId)
            => await _dbSet
                .Where(_ => _.WebsiteId == websiteId)
                .ToListAsync();

        public async Task<IEnumerable<Menu>> GetEnabledByWebsiteAsync(int websiteId)
            => await _dbSet
                .Where(_ => _.WebsiteId == websiteId)
                .Where(_ => _.Status == EntityStatus.Enabled)
                .ToListAsync();
    }
}
