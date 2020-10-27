using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Behlog.Core.Models.Security {
    public class Role: IdentityRole<Guid> {
        public Role() {}

        public Role(string name): this() {
            Name = name;
        }

        public Role(string name, string description): this(name) {
            Description = description;
        }

        public string Description { get; set; }

        public ICollection<UserRole> Users { get; set; }

        public ICollection<RoleClaim> Claims { get; set; }

    }
}
