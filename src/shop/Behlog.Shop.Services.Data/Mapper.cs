using System.Linq;
using System.Collections.Generic;
using Behlog.Core.Models.Shop;
using Mapster;

namespace Behlog.Shop.Services.Data {

    public static class Mapper {

        public static CustomerBasketDto MapToResult(
            this Customer customer, 
            Basket basket,
            ShippingAddress address) 
                => new CustomerBasketDto {
                    CreateDate = basket.CreateDate,
                    CustomerFullName = customer.FullName,
                    CustomerEmail = customer.Email,
                    CustomerMobile = customer.Mobile,
                    CustomerPostalCode = address.PostalCode,
                    CustomerShippingAddress = address.Address,
                    Id = basket.Id,
                    TotalPrice = basket.TotalPrice,
                    TotalTaxAmount = basket.Items.Sum(_=> _.TaxAmount),
                    UserId = basket.UserId,
                    Items = basket.Items.Adapt<List<CustomerBasketItemDto>>()
                };

        public static CustomerInvoiceDto MapToResult(
            this Customer customer,
            Invoice invoice,
            ShippingAddress address)
            => new CustomerInvoiceDto {
                CustomerId = customer.Id,
                CreateDate = invoice.CreateDate,
                CustomerEmail = customer.Email,
                CustomerFullName = customer.FullName,
                CustomerMobile = customer.Mobile,
                CustomerPostalCode = address.PostalCode,
                CustomerShippingAddress = address.Address,
                Items = invoice.Orders.Adapt<List<CustomerInvoiceItemDto>>(),
                InvoiceId = invoice.Id,
                TotalPrice = invoice.TotalPrice,
                TotalTaxAmount = invoice.Orders.Sum(_=> _.TaxAmount),
                InvoiceStatus = invoice.Status
            };
    }
}
