
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Models.System;
using Behlog.Core.Contracts.Repository.System;

namespace Behlog.Repository.System
{
    public class WebsiteRepository: BaseRepository<Website, int>, IWebsiteRepository
    {
        public WebsiteRepository(IBehlogContext context) : base(context) {
        }


        public async Task<Shipping> GetDefaultShippingAsync(int websiteId) 
            => await (from x in _dbSet.Where(_ => _.Id == websiteId)
                        select x.DefaultShipping).FirstOrDefaultAsync();

    }
}
