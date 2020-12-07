using System.Threading.Tasks;
using Behlog.Core.Models.Security;
using Behlog.Services.Dto.Admin.Security;

namespace Behlog.Factories.Contracts.Security
{
    public interface IUserFactory
    {
        Task<User> MakeAsync(AdminCreateUserDto model);
    }
}
