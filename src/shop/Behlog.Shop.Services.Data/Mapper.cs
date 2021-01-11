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
        
    }
}
