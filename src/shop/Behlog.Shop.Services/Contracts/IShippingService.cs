using System;
using System.Threading.Tasks;
using Behlog.Core.Models.Shop;

namespace Behlog.Shop.Services.Contracts {

    public interface IShippingService {

        Task<Shipping> GetDefaultShippingForWebsiteAsync();
    }
}
