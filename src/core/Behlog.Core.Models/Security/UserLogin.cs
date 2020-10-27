using System;
using Behlog.Core.Models.System;
using Microsoft.AspNetCore.Identity;

namespace Behlog.Core.Models.Security {

    public class UserLogin: IdentityUserLogin<Guid> {
        public UserLogin() 
        {
        }

        #region Properties
        public long Id { get; set; }
        public string UserAgent { get; set; }
        public string IP { get; set; }
        public string ReferUrl { get; set; }
        public DateTime LoginTime { get; set; }
        public int WebsiteId { get; set; }
        public string ExtraInfo { get; set; }

        #endregion

        #region Navigations
        public Website Website { get; set; }
        public User User { get; set; }
        #endregion

    }
}
