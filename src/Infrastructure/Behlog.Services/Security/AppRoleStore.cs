using System;
using System.Security.Claims;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Security;
using Behlog.Services.Contracts.Security;
using Behlog.Storage.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Behlog.Services.Security {
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2578
    /// </summary>
    public class AppRoleStore : 
        RoleStore<Role, BehlogContext, Guid, UserRole, RoleClaim>, 
        IAppRoleStore 
    {

        private readonly IBehlogContext _uow;
        private readonly IdentityErrorDescriber _describer;

        public AppRoleStore(
            IBehlogContext uow,
            IdentityErrorDescriber describer)
            : base((BehlogContext)uow, describer) {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _describer = describer ?? throw new ArgumentNullException(nameof(_describer));
        }

        public string ConvertIdToString(int id) {
            throw new NotImplementedException();
        }

        #region BaseClass

        protected override RoleClaim CreateRoleClaim(Role role, Claim claim) {
            return new RoleClaim {
                RoleId = role.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            };
        }

        int IAppRoleStore.ConvertIdFromString(string id) {
            throw new NotImplementedException();
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}
