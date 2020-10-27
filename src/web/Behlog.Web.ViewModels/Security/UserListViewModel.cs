using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Core.Models.Security;
using Behlog.Web.ViewModels.Core;

namespace Behlog.Web.ViewModels.Security
{
    public class UserListViewModel: PagedList<User>
    {

        public ICollection<Role> Roles { get; set; }
    }
}
