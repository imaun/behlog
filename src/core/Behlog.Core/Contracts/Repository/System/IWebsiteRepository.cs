using System.Threading.Tasks;
using Behlog.Core.Models.Shop;
using Behlog.Core.Models.System;

namespace Behlog.Core.Contracts.Repository.System
{
    public interface IWebsiteRepository: IBaseRepository<Website, int>
    {
        Task<Shipping> GetDefaultShippingAsync(int websiteId);
    }
}
