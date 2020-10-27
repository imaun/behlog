using System;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Behlog.Core.Models.Security;
using Behlog.Services.Contracts.Security;

namespace Behlog.Services.Security {
    public class AppClaimsPrincipalFactory: UserClaimsPrincipalFactory<User, Role> {

        public static readonly string PhotoFileName = nameof(PhotoFileName);

        private readonly IOptions<IdentityOptions> _optionsAccessor;
        private readonly IAppRoleManager _roleManager;
        private readonly IAppUserManager _userManager;

        public AppClaimsPrincipalFactory(
            IAppUserManager userManager,
            IAppRoleManager roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base((UserManager<User>)userManager, (RoleManager<Role>)roleManager, optionsAccessor) 
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(_userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(_roleManager));
            _optionsAccessor = optionsAccessor ?? throw new ArgumentNullException(nameof(_optionsAccessor));
        }

        public override async Task<ClaimsPrincipal> CreateAsync(User user) {
            var principal = await base.CreateAsync(user); // adds all `Options.ClaimsIdentity.RoleClaimType -> Role Claims` automatically + `Options.ClaimsIdentity.UserIdClaimType -> userId` & `Options.ClaimsIdentity.UserNameClaimType -> userName`
            addCustomClaims(user, principal);
            return principal;
        }

        private static void addCustomClaims(User user, IPrincipal principal) {
            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.Integer),
                new Claim(ClaimTypes.GivenName, user.Title ?? string.Empty),
                new Claim("WebsiteId", "1", ClaimValueTypes.Integer) //TODO : 
                //new Claim("WebsiteId", ), 
                //new Claim(PhotoFileName, user. ?? string.Empty, ClaimValueTypes.String),
            });
        }
    }
}
