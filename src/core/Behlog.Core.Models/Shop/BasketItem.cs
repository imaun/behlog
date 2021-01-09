using System;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.Shop {

    public class BasketItem {

        public BasketItem() {

        }

        #region Properties
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

        //TODO : Add DiscountPercent

        public decimal TaxAmount { get; set; }

        public decimal TotalPrice { get; set; }

        public BasketItemStatus Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

        #endregion

        #region Navigations
        public Basket Basket { get; set; }
        public Product Product { get; set; }
        public ProductModel Model { get; set; }
        #endregion
    }
}
