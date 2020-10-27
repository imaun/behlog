using System.Collections.Generic;
using Behlog.Core.Models.Base;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;

namespace Behlog.Core.Models.Content {

    public class Section: HasMetaData {

        public Section() {
            RelatedSections = new HashSet<Section>();
        }

        #region Properties
        public int Id { get; set; }
        public int WebsiteId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public PostBodyType BodyType { get; set; }
        public EntityStatus Status { get; set; }
        public string ActionFullUrl { get; set; }
        public string CoverPhoto { get; set; }
        public string IconName { get; set; }
        public string ViewPath { get; set; }
        public int SectionGroupId { get; set; }
        public int? RelatedSectionId { get; set; }
        public int? RelatedPostId { get; set; }
        public int? LangId { get; set; }
        #endregion

        #region Navigations
        public SectionGroup SectionGroup { get; set; }
        public Section RelatedSection { get; set; }
        public Post RelatedPost { get; set; }
        public Language Language { get; set; }
        public ICollection<Section> RelatedSections { get; set; }
        #endregion
    }
}
