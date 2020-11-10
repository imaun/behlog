using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Contracts.Services.Database;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Security;
using Behlog.Core.Models.System;
using Behlog.Services.Contracts.Security;
using Behlog.Services.Contracts.System;
using Behlog.Storage.Core;
using Mapster;
using IdentityResult = Microsoft.AspNetCore.Identity.IdentityResult;
using Behlog.Web.Core.Settings;

namespace Behlog.Services.Database
{
    /// <summary>
    /// Service for Initialize and seed database.
    /// </summary>
    public class DbInitializerService: IDbInitializer {

        private readonly IOptionsSnapshot<BehlogSetting> _settings;
        private readonly IAppUserManager _userManager;
        private readonly ILogger<IDbInitializer> _logger;
        private readonly IAppRoleManager _roleManager;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IDateService _dateSvc;
        private readonly ILanguageService _languageSvc;
        private readonly ILayoutService _layoutSvc;
        private readonly IWebsiteService _websiteSvc;

        #region Properties

        public AdminUserSeed AdminUserSeedInfo => _settings.Value.AdminUserSeedInfo;

        public WebsiteSeed WebsiteSeedInfo => _settings.Value.WebsiteSeedInfo;

        public WebsiteLayoutSeed WebsiteLayoutSeedInfo => _settings.Value.WebsiteLayoutSeedInfo;

        #endregion


        public DbInitializerService(
            IOptionsSnapshot<BehlogSetting> settings,
            IAppUserManager userManager,
            ILogger<IDbInitializer> logger,
            IAppRoleManager roleManager,
            IServiceScopeFactory scopeFactory,
            IDateService dateSvc,
            ILanguageService languageSvc,
            ILayoutService layoutSvc,
            IWebsiteService websiteSvc
        ) {
            logger.CheckArgumentIsNull();
            _logger = logger;

            settings.CheckArgumentIsNull();
            _settings = settings;

            userManager.CheckArgumentIsNull();
            _userManager = userManager;

            logger.CheckArgumentIsNull();
            logger = _logger;

            roleManager.CheckArgumentIsNull();
            _roleManager = roleManager;

            scopeFactory.CheckArgumentIsNull();
            _scopeFactory = scopeFactory;

            dateSvc.CheckArgumentIsNull();
            _dateSvc = dateSvc;

            languageSvc.CheckArgumentIsNull();
            _languageSvc = languageSvc;

            layoutSvc.CheckArgumentIsNull();
            _layoutSvc = layoutSvc;

            websiteSvc.CheckArgumentIsNull();
            _websiteSvc = websiteSvc;
        }

        /// <summary>
        /// Applies any pending migrations for the context to the database.
        /// Will create the database if it does not already exist.
        /// </summary>
        public void Initialize() {
            using var scope = _scopeFactory.CreateScope();
            using var db = scope.ServiceProvider.GetRequiredService<BehlogContext>();
            if (_settings.Value.DbType == AppDatabaseType.InMemory)
                db.Database.EnsureCreated();
            else
                db.Database.Migrate();
        }

        /// <summary>
        /// Adds some default values to the Database
        /// </summary>
        public void SeedData() {
            using var scope = _scopeFactory.CreateScope();
            var dbInitializer = scope.ServiceProvider.GetRequiredService<DbInitializerService>();
            var createAdminResult = dbInitializer.CreateAdminUserAsync().Result;
            if(createAdminResult == (null,IdentityResult.Failed()))
                throw new InvalidOperationException(createAdminResult.Item2.DumpErrors());

            using var db = scope.ServiceProvider.GetRequiredService<BehlogContext>();
            if (!db.Roles.Any()) {
                db.Add(new Role(Consts.Role_Admin));
                db.SaveChanges();
            }

            var adminUser = createAdminResult.Item1;
            var defaultLanguage = _languageSvc
                .CreateDefaultLanguagesAndReturnDefaultLanguageAsync()
                .Result;

            dbInitializer.CreateDefaultWebsite(
                db,
                adminUser, 
                defaultLanguage.Adapt<Language>()
            );
        }

        public async Task<(User,IdentityResult)> CreateAdminUserAsync() {

            var adminUser = await _userManager.FindByNameAsync(AdminUserSeedInfo.Username);
            if(adminUser != null) {
                _logger.LogInformation($"{AdminUserSeedInfo.Username} already existed.");
                return (adminUser, 
                    IdentityResult.Success
                );
            }

            var adminRole = await _roleManager.FindByNameAsync(AdminUserSeedInfo.RoleName);
            if(adminRole != null) {
                _logger.LogInformation($"{AdminUserSeedInfo.RoleName} role already existed.");
            }
            else {
                adminRole = new Role(AdminUserSeedInfo.RoleName);
                var roleResult = await _roleManager.CreateAsync(adminRole);
                if(roleResult == IdentityResult.Failed())
                {
                    _logger.LogError($"'{adminRole.Name}' role creating has failed. {roleResult.DumpErrors()}");
                    return (null,
                        IdentityResult.Failed()
                    );
                }
            }

            adminUser = new User {
                UserName = AdminUserSeedInfo.Username,
                Email = AdminUserSeedInfo.Email,
                EmailConfirmed = true,
                RegisterDate = _dateSvc.UtcNow(),
                Title = AdminUserSeedInfo.Title,
                LockoutEnabled = true,
                Status = UserStatus.Enabled
            };

            var result = await _userManager.CreateAsync(adminUser, AdminUserSeedInfo.Password);
            if(result == IdentityResult.Failed()) {
                _logger.LogError($"'{AdminUserSeedInfo.Username}; user creation has failed. {result.DumpErrors()}");
                return (null, 
                    IdentityResult.Failed()
                );
            }

            var setLockoutResult = await _userManager.SetLockoutEnabledAsync(adminUser, enabled: false);
            if(setLockoutResult == IdentityResult.Failed()) {
                _logger.LogError($"'{AdminUserSeedInfo.Username}' setLockout on user has failed. {setLockoutResult.DumpErrors()}");
                return (null, 
                    IdentityResult.Failed()
                );
            }

            var addRoleResult = await _userManager.AddToRoleAsync(adminUser, AdminUserSeedInfo.RoleName);
            if(addRoleResult == IdentityResult.Failed()) {
                _logger.LogError($"Adding user:'{AdminUserSeedInfo.Username}' to role:'{AdminUserSeedInfo.RoleName}' has failed. {addRoleResult.DumpErrors()}");
                return (null, 
                    IdentityResult.Failed()
                );
            }

            return (
                adminUser, 
                IdentityResult.Success
            );
        }
        
        public void CreateDefaultWebsite(
            BehlogContext db, 
            User adminUser, 
            Language defLanguage
        ) {
            adminUser.CheckArgumentIsNull();
            defLanguage.CheckArgumentIsNull();

            try {
                //First we have to create a website layout if doesn't exist.
                var defaultLayout = db.Layouts.FirstOrDefault(_ => _.Name == Layout.DEF_LayoutName) ?? new Layout {
                    Status = EntityStatus.Enabled,
                    Title = WebsiteLayoutSeedInfo.Title,
                    Name = WebsiteLayoutSeedInfo.Name,
                    Description = WebsiteLayoutSeedInfo.Description,
                    Author = WebsiteLayoutSeedInfo.Author,
                    AuthorEmail = WebsiteLayoutSeedInfo.AuthorEmail,
                    AuthorWebUrl = WebsiteLayoutSeedInfo.AuthorWebUrl,
                    Path = WebsiteLayoutSeedInfo.Path,
                    IsRtl = WebsiteLayoutSeedInfo.IsRtl,
                    OrderNumber = 1,
                    CreateDate = _dateSvc.UtcNow(),
                    ModifyDate = _dateSvc.UtcNow()
                };

                if(defaultLayout.Id == 0) {
                    db.Layouts.Add(defaultLayout);
                    db.SaveChanges();
                }

                //Add the Default Website, if it's not there.
                if (! db.Websites.Any()) {
                    var defaultWebsite = new Website {
                        Name = WebsiteSeedInfo.Name,
                        Url = WebsiteSeedInfo.Url,
                        Description = WebsiteSeedInfo.Description,
                        DefaultLangId = defLanguage.Id,
                        Keywords = WebsiteSeedInfo.Keywords,
                        OwnerId = adminUser.Id,
                        LayoutId = defaultLayout.Id,
                        Title = WebsiteSeedInfo.Title,
                        Status = EntityStatus.Enabled,
                        CreateDate = _dateSvc.UtcNow(),
                        ModifyDate = _dateSvc.UtcNow()
                    };

                    db.Websites.Add(defaultWebsite);
                    db.SaveChanges();
                }

            }
            catch (Exception e) {
                _logger.LogError(e.GetBaseException().Message);
                throw;
            }

            
        }
    }
}
