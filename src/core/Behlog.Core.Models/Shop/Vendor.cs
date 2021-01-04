using System;
using System.Collections.Generic;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Security;

namespace Behlog.Core.Models.Shop {
    /// <summary>
    /// Someone or some company that sells the product on our shop.
    /// </summary>
    public class Vendor {
        public Vendor() {
            Products = new HashSet<Product>();
            ProductModels = new HashSet<ProductModel>();
        }

        #region Properties

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public VendorStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        #endregion

        #region Navigations
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ProductModel> ProductModels { get; set; }
        #endregion
    }
}
