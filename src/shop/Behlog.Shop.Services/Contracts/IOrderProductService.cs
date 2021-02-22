using System;
using System.Threading.Tasks;
using Behlog.Shop.Services.Data;
using Behlog.Core.Models.Shop;

namespace Behlog.Shop.Services.Contracts {

    public interface IOrderProductService {

        /// <summary>
        /// Order a single <see cref="Product"/> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CustomerBasketDto> OrderProductAsync(OrderSingleProductDto model);
        Task<CustomerInvoiceDto> CreateInvoiceAsync(OrderSingleProductDto model);
        Task CreateInvoiceAndPayAsync(Guid basketId);
    }
}
