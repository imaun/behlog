using System;
using System.Collections.Generic;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Security;

namespace Behlog.Core.Models.Shop {

    public class Vendor {
        public Vendor() {
            Products = new HashSet<Product>();
        }

        #region Properties

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public EntityStatus Status { get; set; }


        #endregion

        #region Navigations
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }

        #endregion
    }
}
