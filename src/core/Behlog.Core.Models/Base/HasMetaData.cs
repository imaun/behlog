using System;

namespace Behlog.Core.Models.Base {
    public abstract class HasMetaData {
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public Guid CreatorUserId { get; set; }
        public Guid? ModifierUserId { get; set; }
    }
}
