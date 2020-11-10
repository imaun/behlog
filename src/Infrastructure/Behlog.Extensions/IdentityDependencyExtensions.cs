using System;
using System.Threading.Tasks;
using Behlog.Core.Models.Security;
using Behlog.Core.Security;
using Behlog.Services.Security;
using Behlog.Web.Core.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Behlog.Extensions
{
    public static class IdentityDependencyExtensions
    {
        public static IServiceCollection AddIdentityOptions(
            this IServiceCollection services, BehlogSetting setting
        ) {
            if (setting == null)
                throw new ArgumentNullException(nameof(setting));

            services.AddIdentity<User, Role>(_ => {
                setPasswordOptions(_.Password, setting);
                setSignInOptions(_.SignIn, setting);
                setUserOptions(_.User);
                setLockoutOptions(_.Lockout, setting);
            }).AddUserStore<AppUserStore>()
                .AddUserManager<AppUserManager>()
                .AddRoleStore<AppRoleStore>()
                .AddSignInManager<AppSignInManager>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserContext, UserContext>();

            return services;
        }

        private static void addConfirmEmailDataProtectorTokenOptions(
            this IServiceCollection services, BehlogSetting setting
        ) {
            //services.Configure<IdentityOptions>(options => {
            //    options.Tokens.EmailConfirmationTokenProvider = EmailConfirmationTokenProviderName;
            //});

            //services.Configure<ConfirmEmailDataProtectionTokenProviderOptions>(options => {
            //    options.TokenLifespan = setting.EmailConfirmationTokenProviderLifespan;
            //});
        }

        private static void enableImmediateLogout(this IServiceCollection services) {
            services.Configure<SecurityStampValidatorOptions>(options => {
                // enables immediate logout, after updating the user's stat.
                options.ValidationInterval = TimeSpan.Zero;
                options.OnRefreshingPrincipal = principalContext => {
                    // Invoked when the default security stamp validator replaces the user's ClaimsPrincipal in the cookie.

                    //var newId = new ClaimsIdentity();
                    //newId.AddClaim(new Claim("PreviousName", principalContext.CurrentPrincipal.Identity.Name));
                    //principalContext.NewPrincipal.AddIdentity(newId);

                    return Task.CompletedTask;
                };
            });
        }

        private static void setApplicationCookieOptions(
            IServiceProvider provider, 
            CookieAuthenticationOptions identityOptionsCookies, 
            BehlogSetting setting) 
        {
            identityOptionsCookies.Cookie.Name = setting.CookieOptions.CookieName;
            identityOptionsCookies.Cookie.HttpOnly = true;
            identityOptionsCookies.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            identityOptionsCookies.Cookie.SameSite = SameSiteMode.Lax;
            identityOptionsCookies.Cookie.IsEssential = true; //  this cookie will always be stored regardless of the user's consent

            identityOptionsCookies.ExpireTimeSpan = setting.CookieOptions.ExpireTimeSpan;
            identityOptionsCookies.SlidingExpiration = setting.CookieOptions.SlidingExpiration;
            identityOptionsCookies.LoginPath = setting.CookieOptions.LoginPath;
            identityOptionsCookies.LogoutPath = setting.CookieOptions.LogoutPath;
            identityOptionsCookies.AccessDeniedPath = setting.CookieOptions.AccessDeniedPath;

            if (setting.CookieOptions.UseDistributedCacheTicketStore) {
                // To manage large identity cookies
                identityOptionsCookies.SessionStore = provider.GetRequiredService<ITicketStore>();
            }
        }

        private static void setLockoutOptions(LockoutOptions identityOptionsLockout, BehlogSetting setting) {
            identityOptionsLockout.AllowedForNewUsers = setting.LockoutOptions.AllowedForNewUsers;
            identityOptionsLockout.DefaultLockoutTimeSpan = setting.LockoutOptions.DefaultLockoutTimeSpan;
            identityOptionsLockout.MaxFailedAccessAttempts = setting.LockoutOptions.MaxFailedAccessAttempts;
        }

        private static void setPasswordOptions(PasswordOptions identityOptionsPassword, BehlogSetting setting) {
            identityOptionsPassword.RequireDigit = setting.PasswordOptions.RequireDigit;
            identityOptionsPassword.RequireLowercase = setting.PasswordOptions.RequireLowercase;
            identityOptionsPassword.RequireNonAlphanumeric = setting.PasswordOptions.RequireNonAlphanumeric;
            identityOptionsPassword.RequireUppercase = setting.PasswordOptions.RequireUppercase;
            identityOptionsPassword.RequiredLength = setting.PasswordOptions.RequiredLength;
        }

        private static void setSignInOptions(SignInOptions identityOptionsSignIn, BehlogSetting setting) {
            identityOptionsSignIn.RequireConfirmedEmail = setting.EnableEmailConfirmation;
        }

        private static void setUserOptions(UserOptions identityOptionsUser) {
            identityOptionsUser.RequireUniqueEmail = true;
        }
    }
}
