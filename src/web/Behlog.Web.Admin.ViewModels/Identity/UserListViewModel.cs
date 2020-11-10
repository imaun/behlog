using System.Collections.Generic;
using Behlog.Core.Models.Security;
using Behlog.Web.Core.Models;

namespace Behlog.Web.Admin.ViewModels.Identity
{
    public class UserListViewModel: PagedList<User>
    {
        public ICollection<Role> Roles { get; set; }
    }
}
