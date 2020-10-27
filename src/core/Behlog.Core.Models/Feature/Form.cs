using System.Collections.Generic;
using Behlog.Core.Models.Base;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;

namespace Behlog.Core.Models.Feature {
    public class Form: HasMetaData {

        public Form() { }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int WebsiteId { get; set; }
        public EntityStatus Status { get; set; }
        public string Description { get; set; }

        #endregion

        #region Navigations
        public Website Website { get; set; }
        public ICollection<FormField> Fields { get; set; }

        #endregion
    }
}
