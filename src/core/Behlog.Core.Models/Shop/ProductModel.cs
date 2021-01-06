using System;
using System.Collections.Generic;
using Behlog.Core.Models.Base;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.Shop {
    
    public class ProductModel: HasMetaData {

        public ProductModel() {
            Orders = new HashSet<Order>();
            BasketItems = new HashSet<BasketItem>();
        }

        #region Properties
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public string ColorValue { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CoverPhoto { get; set; }
        public int OrderNumber { get; set; }
        public bool Orderable { get; set; }
        public ProductStatus Status { get; set; }
        public bool NewModel { get; set; }
        public DateTime? NewModelStartDate { get; set; }
        public DateTime? NewModelFinishDate { get; set; }
        public int? VendorId { get; set; }

        #endregion

        #region Navigations
        public Product Product { get; set; }
        public Vendor Vendor { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
        #endregion
    }
}
