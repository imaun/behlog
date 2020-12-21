using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Behlog.Core;
using Behlog.Resources.Strings;
using Behlog.Core.Models.Enum;

namespace Behlog.Web.Common.Extensions {

    public static class Extensions {

        public static List<SelectListItem> ToSelectListItems(this EntityStatus status) =>
             new List<SelectListItem> {
                new SelectListItem(
                    AppTextDisplay.StatusEnable,
                    ((int) EntityStatus.Enabled).ToString(),
                    status == EntityStatus.Enabled),

                new SelectListItem(
                    AppTextDisplay.StatusDisable,
                    ((int) EntityStatus.Disabled).ToString(),
                    status == EntityStatus.Disabled)
            };

        public static List<SelectListItem> ToSelectListItems(this PostStatus status) =>
            new List<SelectListItem> {
                new SelectListItem(
                    AppTextDisplay.PostStatusDraft,
                    ((int) PostStatus.Draft).ToString(),
                    status == PostStatus.Draft),

                new SelectListItem(
                    AppTextDisplay.PostStatusPlanned,
                    ((int) PostStatus.Planned).ToString(),
                    status == PostStatus.Planned),

                new SelectListItem(
                    AppTextDisplay.PostStatusPublished,
                    ((int) PostStatus.Published).ToString(),
                    status == PostStatus.Published)
            };

        public static List<SelectListItem> ToSelectListItems(this CommentStatus status) =>
            new List<SelectListItem> {
                new SelectListItem(
                    AppTextDisplay.CommentStatusDeleted,
                    ((int)CommentStatus.Deleted).ToString(),
                    status == CommentStatus.Deleted),

                new SelectListItem(
                    AppTextDisplay.CommentStatusWaiting,
                    ((int) CommentStatus.Waiting).ToString(),
                    status == CommentStatus.Waiting),

                new SelectListItem(
                    AppTextDisplay.CommentStatusApproved,
                    ((int) CommentStatus.Approved).ToString(),
                    status == CommentStatus.Approved),

                new SelectListItem(
                    AppTextDisplay.CommentStatusRejected,
                    ((int) CommentStatus.Rejected).ToString(),
                    status == CommentStatus.Rejected),

                new SelectListItem(
                    AppTextDisplay.CommentStatusSpam,
                    ((int) CommentStatus.Spam).ToString(),
                    status == CommentStatus.Spam),

                new SelectListItem(
                    AppTextDisplay.CommentStatusViewed,
                    ((int) CommentStatus.Viewed).ToString(),
                    status == CommentStatus.Viewed),

                new SelectListItem(
                    AppTextDisplay.CommentStatusRead,
                    ((int) CommentStatus.Read).ToString(),
                    status == CommentStatus.Read)
            };

        public static List<SelectListItem> ToSelectListItems(this UserStatus? status) =>
            new List<SelectListItem> {
                 new SelectListItem(
                     AppTextDisplay.UserStatusDeleted,
                     ((int) UserStatus.Deleted).ToString(),
                     status == UserStatus.Deleted),

                 new SelectListItem(
                     AppTextDisplay.UserStatusDisabled,
                     ((int) UserStatus.Disabled).ToString(),
                     status == UserStatus.Disabled),

                 new SelectListItem(
                     AppTextDisplay.UserStatusEnabled,
                     ((int) UserStatus.Enabled).ToString(),
                     status == UserStatus.Enabled),

                 new SelectListItem(
                     AppTextDisplay.UserStatusBlocked,
                     ((int) UserStatus.Blocked).ToString(),
                     status == UserStatus.Blocked)
            };

        public static string GetLimitedSummary(this string what, int len = 50) {
            if (string.IsNullOrWhiteSpace(what))
                return string.Empty;

            if (what.Length < len)
                len = what.Length;

            return what.Substring(0, len) + "...";
        }

        public static string GetFullImagePath(this string virtualPath)
            => virtualPath != null
                ? virtualPath.Replace("~", AppHttpContext.BaseUrl)
                : CommonHelper.GetDefaultImagePath();

        public static string GetFullUrl(this string virtualPath) =>
           string.IsNullOrWhiteSpace(virtualPath)
                ? string.Empty
                : virtualPath.Replace("~", AppHttpContext.BaseUrl);

    }

}
