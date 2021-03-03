using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Extensions;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Behlog.Core.Contracts.Repository.System;

namespace Behlog.Repository.System {

    public class WebsiteOptionRepository
        : BaseRepository<WebsiteOption, int>, IWebsiteOptionRepository {

        public WebsiteOptionRepository(IBehlogContext context) : base(context) {
        }

        public async Task<IEnumerable<WebsiteOption>> GetEnabledOptions(
            int websiteId, 
            string category = null) {
            var query = Query()
                .Where(_=> _.WebsiteId == websiteId)
                .Where(_ => _.Status == EntityStatus.Enabled);
            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(_ => _.Category.ToLower() == category.ToLower());

            return await query
                .OrderBy(_ => _.OrderNum)
                .ToListAsync();
        }

        public async Task<WebsiteOption> GetEnabledByKey(int websiteId, string key) 
            => await FirstOrDefaultAsync(_ => _.WebsiteId == websiteId &&
                                            _.Status == EntityStatus.Enabled &&
                                            _.Key.ToLower() == key.ToLower());

        public async Task<WebsiteOption> GetOptionAsync(
            string category,
            string key,
            int? langId) => await FirstOrDefaultAsync(_ => _.Category.ToLower() == category.ToLower() &&
                                                      _.Key.ToLower() == key.ToLower() &&
                                                      _.LangId == langId);

        public async Task<WebsiteOption> GetByKeyAsync(
            int websiteId,
            string key,
            string lang = null) => lang.IsNotNullOrEmpty()
                ? await FirstOrDefaultAsync(_ => _.WebsiteId == websiteId &&
                                                 _.Language.LangKey.ToUpper() == lang.ToUpper() &&
                                                 _.Key.ToUpper() == key.ToUpper())
                : await FirstOrDefaultAsync(_ => _.WebsiteId == websiteId &&
                                                 _.Key.ToUpper() == key.ToUpper());

    }
}
