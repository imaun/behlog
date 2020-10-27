using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Microsoft.EntityFrameworkCore;

namespace Behlog.Repository.System
{
    public class WebsiteOptionRepository: BaseRepository<WebsiteOption, int>, 
        IWebsiteOptionRepository
    {
        public WebsiteOptionRepository(IBehlogContext context) : base(context) {
        }

        public async Task<IEnumerable<WebsiteOption>> GetEnabledOptions(int websiteId, string category = null) {
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
            => await SingleOrDefaultAsync(_ => _.WebsiteId == websiteId &&
                                               _.Key.ToLower() == key.ToLower());

        public async Task<WebsiteOption> GetOptionAsync(
            string category,
            string key,
            int? langId) => await SingleOrDefaultAsync(_ => _.Category.ToLower() == category.ToLower() &&
                                                      _.Key.ToLower() == key.ToLower() &&
                                                      _.LangId == langId);



    }
}
