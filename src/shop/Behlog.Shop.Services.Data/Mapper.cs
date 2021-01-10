using System.Collections.Generic;
using Behlog.Core.Models.Shop;
using Mapster;

namespace Behlog.Shop.Services.Data {

    public static class Mapper {

        public static CustomerBasketDto MapToResult(this Customer customer, Basket basket) 
            => new CustomerBasketDto {
                CreateDate = basket.CreateDate,
                CustomerFullName = customer.FullName,
                Id = basket.Id,
                TotalPrice = basket.TotalPrice,
                UserId = basket.UserId,
                Items = basket.Items.Adapt<List<CustomerBasketItemDto>>()
            };
        
    }
}
