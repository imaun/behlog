using Behlog.Core.Models.Enum;

namespace Behlog.Shop.Services.Data {

    public class ProductMetaResultDto {
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

        #region Navigation's Data
        public string ProductTitle { get; set; }
        #endregion
    }
}
