using System.Threading.Tasks;
using Behlog.Services.Dto.Admin.Security;

namespace Behlog.Services.Contracts.Security
{
    public interface IUserService
    {
        Task<AdminUserIndexDto> GetAdminIndexAsyc(AdminUserIndexFilter filter);
        Task CreateAsync(AdminCreateUserDto model);
    }
}
