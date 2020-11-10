using System.Collections.Generic;
using Behlog.Core.Models.Security;
using Behlog.Web.Core.Models;

namespace Behlog.Web.Core.Security
{
    public class UserListViewModel: PagedList<User>
    {
        public ICollection<Role> Roles { get; set; }
    }
}
