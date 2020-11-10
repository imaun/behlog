using System;
using Microsoft.AspNetCore.Identity;

namespace Behlog.Web.Core.Settings {
    public class BehlogSetting {
        public int WebsiteId { get; set; }
        public WebConfig WebConfig { get; set; }
        public AppDatabaseType DbType { get; set; }
        public AppConnectionString ConnectionStrings { get; set; }
        public AdminUserSeed AdminUserSeedInfo { get; set; }
        public WebsiteSeed WebsiteSeedInfo { get; set; }
        public WebsiteLayoutSeed WebsiteLayoutSeedInfo { get; set; }
        public bool EnableEmailConfirmation { get; set; }
        public TimeSpan EmailConfirmationTokenProviderLifespan { get; set; }
        public int ChangePasswordReminderDays { get; set; }
        public PasswordOptions PasswordOptions { get; set; }
        public CookieOptions CookieOptions { get; set; }
        public LockoutOptions LockoutOptions { get; set; }
        public GlobalViewData ViewData { get; set; }
        public string[] EmailsBanList { get; set; }
        public string[] PasswordsBanList { get; set; }
    }
}
