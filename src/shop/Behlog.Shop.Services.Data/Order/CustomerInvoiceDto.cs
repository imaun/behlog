using Behlog.Core.Models.Enum;
using System;
using System.Collections.Generic;

namespace Behlog.Shop.Services.Data {

    public class CustomerInvoiceDto {

        public CustomerInvoiceDto() {
            Items = new List<CustomerInvoiceItemDto>();
        }

        public int CustomerId { get; set; }
        public int InvoiceId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerShippingAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerPostalCode { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; } 
        public Guid? UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public IEnumerable<CustomerInvoiceItemDto> Items { get; set; }
    }

    public class CustomerInvoiceItemDto {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
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
    }
}
