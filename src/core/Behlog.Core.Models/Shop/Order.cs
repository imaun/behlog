using Behlog.Core.Models.Enum;
using System;

namespace Behlog.Core.Models.Shop {

    public class Order {

        public Order() { }

        #region Properties
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductTitle { get; set; }

        public int? ProductModelId { get; set; }

        public string ProductModelTitle { get; set; }

        public decimal UnitPrice { get; set; }

        public string UnitName { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal? DiscountPercent { get; set; }

        public int Quantity { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal? TaxPercent { get; set; }

        public int? ShippingId { get; set; }

        public int? ShippingAddressId { get; set; }

        public decimal? ShippingAmount { get; set; }

        public decimal TotalPrice { get; set; }

        public InvoiceOrderStatus Status { get; set; } 

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }
        #endregion

        #region Navigations
        public Product Product { get; set; }
        public ProductModel Model { get; set; }
        public Shipping Shipping { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        #endregion
    }
}
