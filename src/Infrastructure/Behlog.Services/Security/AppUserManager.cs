using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DNTCommon.Web.Core;
using Behlog.Core.Extensions;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Security;
using Behlog.Services.Contracts.Security;
using Behlog.Storage.Core;
using Behlog.Web.ViewModels.Search;
using Behlog.Web.ViewModels.Security;

namespace Behlog.Services.Security {
    public class AppUserManager: UserManager<User>, IAppUserManager {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IBehlogContext _uow;
        //private readonly IUsedPasswordsService _usedPasswordsService;
        private readonly IdentityErrorDescriber _errors;
        private readonly ILookupNormalizer _keyNormalizer;
        private readonly ILogger<AppUserManager> _logger;
        private readonly IOptions<IdentityOptions> _optionsAccessor;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IEnumerable<IPasswordValidator<User>> _passwordValidators;
        private readonly IServiceProvider _services;
        private readonly DbSet<User> _users;
        private readonly DbSet<Role> _roles;
        private readonly IAppUserStore _userStore;
        private readonly IEnumerable<IUserValidator<User>> _userValidators;
        private User _currentUserInScope;

        public AppUserManager(
            IAppUserStore store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<AppUserManager> logger,
            IHttpContextAccessor contextAccessor,
            IBehlogContext uow)
            : base ((
                    UserStore<User, Role, BehlogContext, Guid, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>)store,
                    optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger
                ) 
        {
            _userStore = store ?? throw new ArgumentNullException(nameof(_userStore));
            _optionsAccessor = optionsAccessor ?? throw new ArgumentNullException(nameof(_optionsAccessor));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(_passwordHasher));
            _userValidators = userValidators ?? throw new ArgumentNullException(nameof(_userValidators));
            _passwordValidators = passwordValidators ?? throw new ArgumentNullException(nameof(_passwordValidators));
            _keyNormalizer = keyNormalizer ?? throw new ArgumentNullException(nameof(_keyNormalizer));
            _errors = errors ?? throw new ArgumentNullException(nameof(_errors));
            _services = services ?? throw new ArgumentNullException(nameof(_services));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(_contextAccessor));
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _users = uow.Set<User>();
            _roles = uow.Set<Role>();
        }

        #region BaseClass

        string IAppUserManager.CreateTwoFactorRecoveryCode() 
        {
            return base.CreateTwoFactorRecoveryCode();
        }

        Task<PasswordVerificationResult> IAppUserManager.VerifyPasswordAsync(
            IUserPasswordStore<User> store,
            User user, 
            string password) 
        {
            return base.VerifyPasswordAsync(store, user, password);
        }

        public override async Task<IdentityResult> CreateAsync(User user) 
        {
            var result = await base.CreateAsync(user);
            if (result.Succeeded) {
                //await _usedPasswordsService.AddToUsedPasswordsListAsync(user);
            }
            return result;
        }

        public override async Task<IdentityResult> CreateAsync(User user, string password) 
        {
            var result = await base.CreateAsync(user, password);
            if (result.Succeeded) {
                //await _usedPasswordsService.AddToUsedPasswordsListAsync(user);
            }
            return result;
        }

        public override async Task<IdentityResult> ChangePasswordAsync(
            User user, 
            string currentPassword, 
            string newPassword) 
        {
            var result = await base.ChangePasswordAsync(user, currentPassword, newPassword);
            if (result.Succeeded) {
                //await _usedPasswordsService.AddToUsedPasswordsListAsync(user);
            }
            return result;
        }

        public override async Task<IdentityResult> ResetPasswordAsync(
            User user, 
            string token, 
            string newPassword) 
        {
            var result = await base.ResetPasswordAsync(user, token, newPassword);
            if (result.Succeeded) {
                //await _usedPasswordsService.AddToUsedPasswordsListAsync(user);
            }
            return result;
        }

        #endregion

        #region CustomMethods

        public User FindById(Guid userId) {
            return _users.Find(userId);
        }

        public Task<User> FindByIdIncludeUserRolesAsync(Guid userId) {
            return _users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == userId);
        }

        public Task<List<User>> GetAllUsersAsync() {
            return Users.ToListAsync();
        }

        public User GetCurrentUser() {
            if (_currentUserInScope != null) {
                return _currentUserInScope;
            }

            return _currentUserInScope = FindById(GetCurrentUserId());
        }

        public async Task<User> GetCurrentUserAsync() => 
            _currentUserInScope ??= await GetUserAsync(_contextAccessor.HttpContext.User);

        public Guid GetCurrentUserId() => _contextAccessor.HttpContext.User.Identity.GetUserId();
        

        public Guid? CurrentUserId => _contextAccessor.HttpContext.User.Identity.GetUserId();

        IPasswordHasher<User> IAppUserManager.PasswordHasher { get => base.PasswordHasher; set => base.PasswordHasher = value; }

        IList<IUserValidator<User>> IAppUserManager.UserValidators => base.UserValidators;

        IList<IPasswordValidator<User>> IAppUserManager.PasswordValidators => base.PasswordValidators;

        IQueryable<User> IAppUserManager.Users => base.Users;

        public string GetCurrentUserName() => 
            _contextAccessor.HttpContext.User.Identity.GetUserName();

        public async Task<bool> HasPasswordAsync(Guid userId) {
            var user = await FindByIdAsync(userId.ToString());
            return user?.PasswordHash != null;
        }

        public async Task<bool> HasPhoneNumberAsync(Guid userId) {
            var user = await FindByIdAsync(userId.ToString());
            return user?.PhoneNumber != null;
        }

        public async Task<byte[]> GetEmailImageAsync(Guid? userId) {
            if (userId == null)
                return "?".TextToImage(new TextToImageOptions());

            var user = await FindByIdAsync(userId.Value.ToString());
            if (user == null)
                return "?".TextToImage(new TextToImageOptions());

            //if (!user.IsEmailPublic)
            //    return "?".TextToImage(new TextToImageOptions());

            return user.Email.TextToImage(new TextToImageOptions());
        }

        public async Task<UserListViewModel> GetPagedUsersListAsync(SearchUserViewModel model, int pageNumber) {
            return new UserListViewModel();
            //var skipRecords = pageNumber * model.MaxNumberOfRows;
            //var query = _users.Include(x => x.Roles).AsNoTracking();

            //if (!model.ShowAllUsers) {
            //    query = query.Where(x => x.Status == model.UserIsActive);
            //}

            //if (!string.IsNullOrWhiteSpace(model.TextToFind)) {
            //    model.TextToFind = model.TextToFind.ApplyCorrectYeKe();

            //    if (model.IsPartOfEmail) {
            //        query = query.Where(x => x.Email.Contains(model.TextToFind));
            //    }

            //    if (model.IsUserId) {
            //        if (int.TryParse(model.TextToFind, out int userId)) {
            //            query = query.Where(x => x.Id == userId);
            //        }
            //    }

            //    if (model.IsPartOfName) {
            //        query = query.Where(x => x.Title.Contains(model.TextToFind));
            //    }

            //    if (model.IsPartOfLastName) {
            //        query = query.Where(x => x.Title.Contains(model.TextToFind));
            //    }

            //    if (model.IsPartOfUserName) {
            //        query = query.Where(x => x.UserName.Contains(model.TextToFind));
            //    }

                
            //}

            //if (model.HasEmailConfirmed) {
            //    query = query.Where(x => x.EmailConfirmed);
            //}

            //if (model.UserIsLockedOut) {
            //    query = query.Where(x => x.LockoutEnd != null);
            //}

            //if (model.HasTwoFactorEnabled) {
            //    query = query.Where(x => x.TwoFactorEnabled);
            //}

            //query = query.OrderBy(x => x.Id);
            //return new PagedUsersListViewModel {
            //    Paging =
            //    {
            //        TotalItems = await query.CountAsync()
            //    },
            //    Users = await query.Skip(skipRecords).Take(model.MaxNumberOfRows).ToListAsync(),
            //    Roles = await _roles.ToListAsync()
            //};
        }

        public async Task<UserListViewModel> GetPagedUsersListAsync(
            int pageNumber, int recordsPerPage,
            string sortByField, SortOrder sortOrder,
            bool showAllUsers) 
        {

            return new UserListViewModel();
            //var skipRecords = pageNumber * recordsPerPage;
            //var query = _users.Include(x => x.Roles).AsNoTracking();

            //if (!showAllUsers) {
            //    query = query.Where(x => x.IsActive);
            //}

            //switch (sortByField) {
            //    case nameof(User.Id):
            //        query = sortOrder == SortOrder.Descending ? query.OrderByDescending(x => x.Id) : query.OrderBy(x => x.Id);
            //        break;
            //    default:
            //        query = sortOrder == SortOrder.Descending ? query.OrderByDescending(x => x.Id) : query.OrderBy(x => x.Id);
            //        break;
            //}

            //return new PagedUsersListViewModel {
            //    Paging =
            //    {
            //        TotalItems = await query.CountAsync()
            //    },
            //    Users = await query.Skip(skipRecords).Take(recordsPerPage).ToListAsync(),
            //    Roles = await _roles.ToListAsync()
            //};
        }

        public async Task<IdentityResult> UpdateUserAndSecurityStampAsync(
            Guid userId, 
            Action<User> action) 
        {
            var user = await FindByIdIncludeUserRolesAsync(userId);
            if (user == null) {
                return IdentityResult.Failed(new IdentityError {
                    Code = "UserNotFound",
                    Description = "کاربر مورد نظر یافت نشد."
                });
            }

            action(user);

            var result = await UpdateAsync(user);
            if (!result.Succeeded) {
                return result;
            }
            return await UpdateSecurityStampAsync(user);
        }

        public async Task<IdentityResult> AddOrUpdateUserRolesAsync(Guid userId, 
            IList<Guid> selectedRoleIds, 
            Action<User> action = null) 
        {
            var user = await FindByIdIncludeUserRolesAsync(userId);
            if (user == null) {
                return IdentityResult.Failed(new IdentityError {
                    Code = "UserNotFound",
                    Description = "کاربر مورد نظر یافت نشد."
                });
            }

            var currentUserRoleIds = user.Roles.Select(x => x.RoleId).ToList();

            if (selectedRoleIds == null) {
                selectedRoleIds = new List<Guid>();
            }

            var newRolesToAdd = selectedRoleIds.Except(currentUserRoleIds).ToList();
            foreach (var roleId in newRolesToAdd) {
                user.Roles.Add(new UserRole { RoleId = roleId, UserId = user.Id });
            }

            var removedRoles = currentUserRoleIds.Except(selectedRoleIds).ToList();
            foreach (var roleId in removedRoles) {
                var userRole = user.Roles.SingleOrDefault(ur => ur.RoleId == roleId);
                if (userRole != null) {
                    user.Roles.Remove(userRole);
                }
            }

            action?.Invoke(user);

            var result = await UpdateAsync(user);
            if (!result.Succeeded) {
                return result;
            }
            return await UpdateSecurityStampAsync(user);
        }

        Task<IdentityResult> IAppUserManager.UpdatePasswordHash(User user, string newPassword, bool validatePassword) {
            return base.UpdatePasswordHash(user, newPassword, validatePassword);
        }

        #endregion
    }
}
