using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Security;
using Behlog.Services.Contracts.Security;
using Behlog.Storage.Core;

namespace Behlog.Services.Security {
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2578
    /// </summary>
    public class AppUserStore :
        UserStore<User, Role, BehlogContext, Guid, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>,
        IAppUserStore 
    {
        private readonly IBehlogContext _uow;
        private readonly IdentityErrorDescriber _describer;

        public AppUserStore(
            IBehlogContext uow,
            IdentityErrorDescriber describer) 
            : base((BehlogContext)uow, describer) 
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _describer = describer ?? throw new ArgumentNullException(nameof(_describer));
        }

        #region BaseClass

        protected override UserClaim CreateUserClaim(User user, Claim claim) {
            var userClaim = new UserClaim { UserId = user.Id };
            userClaim.InitializeFromClaim(claim);
            return userClaim;
        }

        protected override UserLogin CreateUserLogin(User user, UserLoginInfo login) {
            return new UserLogin {
                UserId = user.Id,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName
            };
        }

        protected override UserRole CreateUserRole(User user, Role role) {
            return new UserRole {
                UserId = user.Id,
                RoleId = role.Id
            };
        }

        protected override UserToken CreateUserToken(User user, string loginProvider, string name, string value) {
            return new UserToken {
                UserId = user.Id,
                LoginProvider = loginProvider,
                Name = name,
                Value = value
            };
        }

        Task IAppUserStore.AddUserTokenAsync(UserToken token) 
            => base.AddUserTokenAsync(token);

        Task<Role> IAppUserStore.FindRoleAsync(string normalizedRoleName, CancellationToken cancellationToken) 
            => base.FindRoleAsync(normalizedRoleName, cancellationToken);
        
        Task<UserToken> IAppUserStore.FindTokenAsync(User user, string loginProvider, string name, CancellationToken cancellationToken)
            => base.FindTokenAsync(user, loginProvider, name, cancellationToken);

        Task<User> IAppUserStore.FindUserAsync(Guid userId, CancellationToken cancellationToken) 
            => base.FindUserAsync(userId, cancellationToken);
        
        Task<UserLogin> IAppUserStore.FindUserLoginAsync(Guid userId, string loginProvider, string providerKey, CancellationToken cancellationToken)
            => base.FindUserLoginAsync(userId, loginProvider, providerKey, cancellationToken);

        Task<UserLogin> IAppUserStore.FindUserLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
            => base.FindUserLoginAsync(loginProvider, providerKey, cancellationToken);

        Task<UserRole> IAppUserStore.FindUserRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken)
            => base.FindUserRoleAsync(userId, roleId, cancellationToken);

        Task IAppUserStore.RemoveUserTokenAsync(UserToken token)
            => base.RemoveUserTokenAsync(token);

        #endregion

        #region CustomMethods

        // Add custom methods here

        #endregion
    }
}
