using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using System.Collections.Generic;

namespace Behlog.Core.Models.Shop {
    public class ShippingAddress {

        public ShippingAddress() {
            Orders = new HashSet<Order>();
            Invoices = new HashSet<Invoice>();
        }

        #region Properties
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public EntityStatus Status { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        #endregion

        #region Navigations
        public Customer Customer { get; set; }
        public City City { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        #endregion

    }
}
