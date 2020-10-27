using System;
using Microsoft.AspNetCore.Identity;

namespace Behlog.Core.Models.Security {
    public class RoleClaim: IdentityRoleClaim<Guid> {
        public virtual Role Role { get; set; }
    }
}
