using System;
using System.Collections.Generic;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.Shop {
    public class Basket {

        public Basket() {
            Items = new HashSet<BasketItem>();
        }

        #region Properties
        public Guid Id { get; set; }

        public int WebsiteId { get; set; }

        public int CustomerId { get; set; }

        public BasketStatus Status { get; set; }

        public decimal TotalPrice { get; set; }

        public string SessionId { get; set; }

        public string Ip { get; set; }

        public string UserAgent { get; set; }

        public string CreatedFormUrl { get; set; }

        public Guid? UserId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }
        #endregion

        #region Navigations
        public Website Website { get; set; }
        public Customer Customer { get; set; }
        public ICollection<BasketItem> Items { get; set; }
        #endregion
    }
}
