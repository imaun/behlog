using Behlog.Core.Models.Shop;
using Behlog.Shop.Services.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Behlog.Shop.Factories.Contracts {

    public interface ICustomerFactory {

        Customer BuildRealCustomerFromOrder(OrderSingleProductDto model);

        Task<Basket> AddBasketAsync(
            Customer customer,
            Product product,
            ProductModel productModel,
            OrderSingleProductDto order);

        Task<Invoice> AddInvoiceAsync(
            Customer customer,
            IEnumerable<Order> orders,
            ShippingAddress address,
            Shipping shipping);

        Invoice AddInvoice(
            Customer customer,
            Product product,
            ProductModel productModel,
            OrderSingleProductDto order,
            DateTime dueDate,
            ShippingAddress shippingAddress,
            int? shippingId = null);
    }
}
