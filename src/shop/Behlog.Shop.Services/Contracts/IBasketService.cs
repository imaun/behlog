using System;
using System.Threading.Tasks;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Services.Contracts {

    public interface IBasketService {

        Task<CustomerBasketDto> GetCustomerBasketAsync(Guid basketId);
    }
}
