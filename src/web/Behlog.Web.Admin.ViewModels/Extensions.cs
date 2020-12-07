using System;
using Behlog.Core.Models.Enum;

namespace Behlog.Web.Admin.ViewModels.Extensions {
    public static class Extensions {

        public static UserStatus? ToUserStatus(this string value) {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            try {
                return (UserStatus)Convert.ToInt32(value);
            }
            catch {
                return null;
            }
        }


    }
}
