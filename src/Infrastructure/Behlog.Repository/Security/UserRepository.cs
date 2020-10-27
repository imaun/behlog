using System;
using Behlog.Core.Models.Security;
using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.Security;

namespace Behlog.Repository.Security
{
    public class UserRepository: BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(IBehlogContext context) : base(context) {
        }
    }
}
