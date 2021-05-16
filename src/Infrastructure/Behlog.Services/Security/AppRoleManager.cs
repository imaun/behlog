using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Behlog.Core.Extensions;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Security;
using Behlog.Services.Contracts.Security;
using Behlog.Storage.Core;
using Behlog.Web.Core.Security;

namespace Behlog.Services.Security {


    /// <summary>
    /// More info: http://www.dotnettips.info/post/2578
    /// </summary>
    public class AppRoleManager: RoleManager<Role>, IAppRoleManager {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IBehlogContext _db;
        private readonly IdentityErrorDescriber _errors;
        private readonly ILookupNormalizer _keyNormalizer;
        private readonly ILogger<AppRoleManager> _logger;
        private readonly IEnumerable<IRoleValidator<Role>> _roleValidators;
        private readonly IAppRoleStore _store;
        private readonly DbSet<User> _users;

        public AppRoleManager(
            IAppRoleStore store,
            IEnumerable<IRoleValidator<Role>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<AppRoleManager> logger,
            IHttpContextAccessor contextAccessor,
            IBehlogContext uow) 
            : base((RoleStore<Role, BehlogContext, Guid, UserRole, RoleClaim>)store, roleValidators, keyNormalizer, errors, logger) 
        {
            _store = store ?? throw new ArgumentNullException(nameof(_store));
            _roleValidators = roleValidators ?? throw new ArgumentNullException(nameof(_roleValidators));
            _keyNormalizer = keyNormalizer ?? throw new ArgumentNullException(nameof(_keyNormalizer));
            _errors = errors ?? throw new ArgumentNullException(nameof(_errors));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(_contextAccessor));
            _db = uow ?? throw new ArgumentNullException(nameof(_db));
            _users = _db.Set<User>();
        }

        private Guid _currentUserId => _contextAccessor.HttpContext.User.Identity.GetUserId();

        public IList<Role> FindCurrentUserRoles() => FindUserRoles(_currentUserId);

        public IList<Role> FindUserRoles(Guid userId) 
            => (from role in Roles
                from user in role.Users
                where user.UserId == userId
                select role).OrderBy(_=> _.Name)
                            .ToList();

        public async Task<List<Role>> GetAllCustomRolesAsync() => await Roles.ToListAsync();
        
        public IList<RoleUsersCountViewModel> GetAllCustomRolesAndUsersCountList() 
            => Roles.Select(role =>
                                    new RoleUsersCountViewModel {
                                        Role = role,
                                        UsersCount = role.Users.Count()
                                    }
                            ).ToList();
        
        public async Task<UserListViewModel> GetUsersInRoleListAsync(
                Guid roleId,
                int pageNumber, int recordsPerPage,
                string sortByField, SortOrder sortOrder,
                bool showAllUsers) {
            var skipRecords = pageNumber * recordsPerPage;

            var roleUserIdsQuery = from role in Roles
                                   where role.Id == roleId
                                   from user in role.Users
                                   select user.UserId;
            var query = _users.Include(user => user.Roles)
                              .Where(user => roleUserIdsQuery.Contains(user.Id))
                         .AsNoTracking();

            if (!showAllUsers) {
                query = query.Where(x => x.Status == UserStatus.Enabled);
            }

            switch (sortByField) {
                case nameof(User.Id):
                    query = sortOrder == SortOrder.Descending ? query.OrderByDescending(x => x.Id) : query.OrderBy(x => x.Id);
                    break;
                default:
                    query = sortOrder == SortOrder.Descending ? query.OrderByDescending(x => x.Id) : query.OrderBy(x => x.Id);
                    break;
            }

            return new UserListViewModel {
                TotalCount = await query.CountAsync(),
                Items = await query.Skip(skipRecords)
                    .Take(recordsPerPage)
                    .ToListAsync(),
                Roles = await Roles.ToListAsync()
            };
        }

        public IList<User> GetUsersInRole(string roleName) 
            => _users.Where(_ => (from role in Roles
                                    where role.Name == roleName
                                    from user in role.Users
                                    select user.UserId)
                                .Contains(_.Id))
                                .ToList();

        public IList<Role> GetRolesForCurrentUser() => GetRolesForUser(_currentUserId);

        public IList<Role> GetRolesForUser(Guid userId) {
            var roles = FindUserRoles(userId);
            if (roles == null || !roles.Any()) {
                return new List<Role>();
            }

            return roles.ToList();
        }

        public IList<UserRole> GetUserRolesInRole(string roleName)
            => Roles.Where(_ => _.Name == roleName)
                    .SelectMany(_ => _.Users)
                    .ToList();

        public bool IsCurrentUserInRole(string roleName) => IsUserInRole(_currentUserId, roleName);

        public bool IsUserInRole(Guid userId, string roleName) 
            => (from role in Roles
                    where role.Name == roleName
                    from user in role.Users
                    where user.UserId == userId
                    select role).FirstOrDefault() != null;

        public async Task<Role> FindRoleIncludeRoleClaimsAsync(Guid roleId) 
            => await Roles.Include(x => x.Claims).FirstOrDefaultAsync(x => x.Id == roleId);

        public async Task<IdentityResult> AddOrUpdateRoleClaimsAsync(
            Guid roleId,
            string roleClaimType,
            IList<string> selectedRoleClaimValues) {
            var role = await FindRoleIncludeRoleClaimsAsync(roleId);
            if (role == null) {
                return IdentityResult.Failed(new IdentityError {
                    Code = "RoleNotFound",
                    Description = "نقش مورد نظر یافت نشد."
                });
            }

            var currentRoleClaimValues = role.Claims.Where(roleClaim => roleClaim.ClaimType == roleClaimType)
                                                    .Select(roleClaim => roleClaim.ClaimValue)
                                                    .ToList();

            selectedRoleClaimValues ??= new List<string>();
            var newClaimValuesToAdd = selectedRoleClaimValues.Except(currentRoleClaimValues).ToList();
            foreach (var claimValue in newClaimValuesToAdd) {
                role.Claims.Add(new RoleClaim {
                    RoleId = role.Id,
                    ClaimType = roleClaimType,
                    ClaimValue = claimValue
                });
            }

            var removedClaimValues = currentRoleClaimValues.Except(selectedRoleClaimValues).ToList();
            foreach (var claimValue in removedClaimValues) {
                var roleClaim = role.Claims.SingleOrDefault(rc => rc.ClaimValue == claimValue &&
                                                                  rc.ClaimType == roleClaimType);
                if (roleClaim != null) {
                    role.Claims.Remove(roleClaim);
                }
            }

            return await UpdateAsync(role);
        }

        private Guid getCurrentUserId() => _contextAccessor.HttpContext.User.Identity.GetUserId();

    }
}
