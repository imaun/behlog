using System;
using Microsoft.AspNetCore.Identity;

namespace Behlog.Core.Models.Security {
    public class UserToken: IdentityUserToken<Guid> {
        public virtual User User { get; set; }
    }
}
