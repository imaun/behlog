using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Models.Shop;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Factories.Contracts {

    public interface IProductFactory 
    {

        Task<Order> AddSingleOrderAsync(Product product, OrderSingleProductDto model);
    }
}
