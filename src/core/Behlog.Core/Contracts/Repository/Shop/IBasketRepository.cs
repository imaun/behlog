using System;
using System.Threading.Tasks;
using Behlog.Core.Models.Shop;

namespace Behlog.Core.Contracts.Repository.Shop {

    public interface IBasketRepository: IBaseRepository<Basket, Guid> {

        Task<Basket> GetWithCustomerInfoAsync(Guid id);
    }
}
