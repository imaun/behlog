using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Behlog.Core.Contracts.Repository.System;

namespace Behlog.Repository.System {

    public class MenuRepository: BaseRepository<Menu, int>, IMenuRepository {

        public MenuRepository(IBehlogContext context) : base(context) {
        }

        public async Task<IEnumerable<Menu>> GetByWebsiteAsync(
            int websiteId,
            string lang = null)
            => lang.IsNotNullOrEmpty()
                ? await _dbSet
                    .Where(_ => _.WebsiteId == websiteId)
                    .Where(_ => _.Language.LangKey.ToUpper() == lang.ToUpper())
                    .ToListAsync()
                : await _dbSet
                    .Where(_ => _.WebsiteId == websiteId)
                    .ToListAsync();

        public async Task<IEnumerable<Menu>> GetEnabledByWebsiteAsync(
            int websiteId,
            string lang = null)
            => lang.IsNotNullOrEmpty()
                ? await _dbSet
                    .Where(_ => _.WebsiteId == websiteId)
                    .Where(_ => _.Language.LangKey.ToUpper() == lang.ToUpper())
                    .Where(_ => _.Status == EntityStatus.Enabled)
                    .ToListAsync()
                : await _dbSet
                    .Where(_ => _.WebsiteId == websiteId)
                    .Where(_ => _.Status == EntityStatus.Enabled)
                    .ToListAsync();
    }
}
