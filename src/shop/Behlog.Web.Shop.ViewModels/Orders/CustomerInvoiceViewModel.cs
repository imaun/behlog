using System;
using System.Collections.Generic;
using DNTPersianUtils.Core;
using Behlog.Core.Models.Enum;
using Behlog.Core.Extensions;

namespace Behlog.Web.Shop.ViewModels {

    public class CustomerInvoiceViewModel {

        public CustomerInvoiceViewModel() {
            InvoiceInfo = new InvoiceInfoViewModel();
            Items = new List<CustomerInvoiceItemViewModel>();
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
        public string CurrencyTitle { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public string InvoiceStatusText => InvoiceStatus.ToDisplay();
        public Guid? UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDateDisplay => CreateDate.ToPersianDateTextify();
        public InvoiceInfoViewModel InvoiceInfo { get; set; }
        public IEnumerable<CustomerInvoiceItemViewModel> Items { get; set; }
    }

    public class CustomerInvoiceItemViewModel {
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
