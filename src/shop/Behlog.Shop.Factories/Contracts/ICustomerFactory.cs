using Behlog.Core.Models.Shop;
using Behlog.Shop.Services.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Behlog.Shop.Factories.Contracts {

    public interface ICustomerFactory {

        Customer BuildRealCustomerFromOrder(OrderSingleProductDto model);

        Task<Invoice> AddInvoiceAsync(
            Customer customer,
            IEnumerable<Order> orders,
            ShippingAddress address,
            Shipping shipping);
    }
}
