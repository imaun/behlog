using System;
using System.Collections.Generic;
using Behlog.Core.Models.Enum;

namespace Behlog.Shop.Services.Data {

    public class CustomerBasketDto {
        public CustomerBasketDto() {
            Items = new List<CustomerBasketItemDto>();
        }

        public Guid Id { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerShippingAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerPostalCode { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public Guid? UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public IEnumerable<CustomerBasketItemDto> Items { get; set; }
    }

    public class CustomerBasketItemDto {
        public long Id { get; set; }
        public Guid BasketId { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int? ProductModelId { get; set; }
        public string ProductModelTitle { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitName { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public BasketItemStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
    }

}
