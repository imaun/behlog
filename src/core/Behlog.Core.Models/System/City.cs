using System.Collections.Generic;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Shop;

namespace Behlog.Core.Models.System
{
    public class City {

        public City() {
            ShippingAddresses = new HashSet<ShippingAddress>();
        }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public EntityStatus Status { get; set; }
        public int? ParentId { get; set; }
        public CityType Kind { get; set; }
        public string Description { get; set; }

        #endregion

        #region Navigations
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }

        #endregion
    }
}
