using Behlog.Core.Models.Security;

namespace Behlog.Web.Admin.ViewModels.Identity
{
    public class RoleUsersCountViewModel
    {
        public Role Role { get; set; }
        public int UsersCount { get; set; }
    }
}
