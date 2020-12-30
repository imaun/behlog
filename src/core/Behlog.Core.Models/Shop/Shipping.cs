using System;
using System.Collections.Generic;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.Shop
{
    public class Shipping {

        public Shipping() {
            Invoices = new HashSet<Invoice>();
            Orders = new HashSet<Order>();
        }

        #region Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsFree { get; set; }

        public int MinDeliveryDays { get; set; }

        public int MaxDeliveryDays { get; set; }

        public EntityStatus Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

        #endregion

        #region Navigations
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Order> Orders { get; set; }
        #endregion
    }
}
