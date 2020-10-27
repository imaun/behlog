using Behlog.Core.Models.Base;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Enum;
using System.Collections.Generic;

namespace Behlog.Core.Models.Content {

    public class SectionGroup: HasMetaData {

        public SectionGroup() {
            Sections = new HashSet<Section>();
            SubGroups = new HashSet<SectionGroup>();
        }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
        public int? ParentId { get; set; }
        public int WebsiteId { get; set; }
        #endregion

        #region Navigations
        public Website Website { get; set; }
        public SectionGroup Parent { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<SectionGroup> SubGroups { get; set; }
        #endregion
    }
}