using System.Collections.Generic;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.System {
    
    public class Currency {

        public Currency() {
            WebsitesHasThisAsDefault = new HashSet<Website>();
        }
        
        #region Properties

        public int Id { get; set; }
        public string Title { get; set; }
        public string Sign { get; set; }
        public decimal Rate { get; set; }
        public bool IsBase { get; set; }
        public EntityStatus Status { get; set; }
        public string Description { get; set; }
        #endregion

        #region Navigations

        public ICollection<Website> WebsitesHasThisAsDefault { get; set; }

        #endregion
    }
}
