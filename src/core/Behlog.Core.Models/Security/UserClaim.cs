using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Behlog.Core.Models.Security {
    public class UserClaim: IdentityUserClaim<Guid> {

        public virtual User User { get; set; }

    }
}
