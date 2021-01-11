using System;
using System.Collections.Generic;
using DNTPersianUtils.Core;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Core;

namespace Behlog.Web.Shop.ViewModels {

    public class CustomerBasketViewModel {

        public CustomerBasketViewModel() {
            Items = new List<CustomerBasketItemViewModel>();
            InvoiceInfo = new InvoiceInfoViewModel();
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
        public string CreateDateDisplay => CreateDate.ToPersianDateTextify();
        public InvoiceInfoViewModel InvoiceInfo { get; set; }
        public IEnumerable<CustomerBasketItemViewModel> Items { get; set; }
    }

    public class CustomerBasketItemViewModel
    {
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
        public string StatusDisplay => Status.ToDisplay();
        public DateTime CreateDate { get; set; }
        public string CreateDateDisplay => CreateDate.ToPersianDateTextify();
    }
}
