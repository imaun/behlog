using System.Collections.Generic;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.Shop {
    public class Brand {
        public Brand() {
            Products = new HashSet<Product>();
        }

        #region Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string CoverPhoto { get; set; }

        public EntityStatus Status { get; set; }

        #endregion

        #region Navigations
        public ICollection<Product> Products { get; set; }
        #endregion
    }
}
