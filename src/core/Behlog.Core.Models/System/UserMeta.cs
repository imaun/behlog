using System;
using Behlog.Core.Models.Base;
using Behlog.Core.Models.Security;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.System {
    public class UserMeta: HasMetaData {

        public UserMeta() { }

        #region Properties

        public int Id { get; set; }
        public string Title { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public string Category { get; set; }
        public int? LangId { get; set; }
        public EntityStatus Status { get; set; }
        public Guid UserId { get; set; }

        #endregion

        #region Navigations
        public User User { get; set; }
        public Language Language { get; set; }
        #endregion
    }
}
