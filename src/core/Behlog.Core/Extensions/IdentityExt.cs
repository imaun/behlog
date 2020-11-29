using System;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Behlog.Core.Extensions {
    public static class IdentityExtensions {

        public static string DumpErrors(this IdentityResult result, bool useHtmlNewLine = false) {
            var results = new StringBuilder();
            if (!result.Succeeded) {
                foreach (var error in result.Errors) {
                    var errorDescription = error.Description;
                    if (string.IsNullOrWhiteSpace(errorDescription)) {
                        continue;
                    }

                    if (!useHtmlNewLine) {
                        results.AppendLine(errorDescription);
                    }
                    else {
                        results.Append(errorDescription).AppendLine("<br/>");
                    }
                }
            }
            return results.ToString();
        }

        public static string FindFirstValue(this ClaimsIdentity identity, string claimType) {
            return identity?.FindFirst(claimType)?.Value;
        }

        public static string GetUserClaimValue(this IIdentity identity, string claimType) {
            var identity1 = identity as ClaimsIdentity;
            return identity1?.FindFirstValue(claimType);
        }

        public static string GetUserFirstName(this IIdentity identity) {
            return identity?.GetUserClaimValue(ClaimTypes.GivenName);
        }

        public static string GetUserWebsiteId(this IIdentity identity) =>
            identity?.GetUserClaimValue("WebsiteId"); //TODO:

        public static T GetUserId<T>(this IIdentity identity) where T : IConvertible {
            var firstValue = identity?.GetUserClaimValue(ClaimTypes.NameIdentifier);
            return firstValue != null
                ? (T)Convert.ChangeType(firstValue, typeof(T), CultureInfo.InvariantCulture)
                : default;
        }

        public static Guid GetUserId(this IIdentity identity) {
            var value =  identity?.GetUserClaimValue(ClaimTypes.NameIdentifier);
            if(string.IsNullOrWhiteSpace(value))
                throw new InvalidOperationException("UserId claim not found.");

            if (Guid.TryParse(value, out Guid userId))
                return userId;
            else
                throw new InvalidOperationException("UserId value is not a valid GUID.");
        }

        public static string GetUserLastName(this IIdentity identity) {
            return identity?.GetUserClaimValue(ClaimTypes.Surname);
        }

        public static string GetUserFullName(this IIdentity identity) {
            return $"{GetUserFirstName(identity)} {GetUserLastName(identity)}";
        }

        public static string GetUserDisplayName(this IIdentity identity) {
            var fullName = GetUserFullName(identity);
            return string.IsNullOrWhiteSpace(fullName) ? GetUserName(identity) : fullName;
        }

        public static string GetUserName(this IIdentity identity) {
            return identity?.GetUserClaimValue(ClaimTypes.Name);
        }
    }
}
