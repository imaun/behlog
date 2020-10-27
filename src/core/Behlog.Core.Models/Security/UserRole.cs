using System;
using Microsoft.AspNetCore.Identity;

namespace Behlog.Core.Models.Security {
    public class UserRole: IdentityUserRole<Guid> {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
