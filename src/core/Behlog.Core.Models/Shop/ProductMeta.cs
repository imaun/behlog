using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;

namespace Behlog.Core.Models.Shop {
    public class ProductMeta {
        public ProductMeta() { }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public string Category { get; set; }
        public int? LangId { get; set; }
        public int ProductId { get; set; }
        public string IconName { get; set; }
        public string CoverPhoto { get; set; }
        public EntityStatus Status { get; set; }
        public int OrderNumber { get; set; }
        #endregion

        #region Navigations
        public Product Product { get; set; }
        public Language Language { get; set; }
        #endregion
    }
}
