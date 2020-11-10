using Behlog.Core.Models.Security;

namespace Behlog.Web.Core.Security
{
    public class RoleUsersCountViewModel
    {
        public Role Role { get; set; }
        public int UsersCount { get; set; }
    }
}
