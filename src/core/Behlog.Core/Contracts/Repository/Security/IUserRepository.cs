using System;
using System.Threading.Tasks;
using Behlog.Core.Models.Security;

namespace Behlog.Core.Contracts.Repository.Security
{
    public interface IUserRepository: IBaseRepository<User, Guid>
    {
    }
}
