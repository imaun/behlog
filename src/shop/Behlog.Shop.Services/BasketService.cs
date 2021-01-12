using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository.Shop;
using Behlog.Shop.Services.Contracts;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Services {

    public class BasketService : IBasketService {

        //private readonly IBasketRepository

        public BasketService() {

        }

        public Task<CustomerBasketDto> GetCustomerBasketAsync(Guid basketId) {
            throw new NotImplementedException();
        }
    }
}
