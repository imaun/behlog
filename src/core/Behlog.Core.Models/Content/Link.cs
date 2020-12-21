using Behlog.Core.Models.Base;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;

namespace Behlog.Core.Models.Content {
    public class Link: HasMetaData {

        public Link() { }

        #region Properties

        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int? CategoryId { get; set; }
        public string Target { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
        public int WebsiteId { get; set; }

        #endregion

        #region Navigations
        public Category Category { get; set; }
        public Website Website { get; set; }

        #endregion
    }
}
