using System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Content;

namespace Behlog.Core.Models.Shop {
    public class ProductPrice {

        public ProductPrice() {

        }

        #region Properties
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal DiscountPercent { get; set; }
        public EntityStatus Status { get; set; }

        #endregion

        #region Navigations
        public Product Product { get; set; }

        #endregion
    }
}
