using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Behlog.Core;
using Behlog.Resources.Strings;
using Behlog.Core.Models.Enum;

namespace Behlog.Web.Common.Extensions
{
    public static class Extensions
    {
       
        public static List<SelectListItem> ToSelectListItems(this EntityStatus status) =>
             new List<SelectListItem> {
                new SelectListItem(
                    AppTextDisplay.StatusEnable,
                    ((int) EntityStatus.Enabled).ToString(),
                    status == EntityStatus.Enabled
                ),
                new SelectListItem(
                    AppTextDisplay.StatusDisable,
                    ((int) EntityStatus.Disabled).ToString(),
                    status == EntityStatus.Disabled
                )
            };

        public static List<SelectListItem> ToSelectListItems(this PostStatus status) =>
            new List<SelectListItem> {
                new SelectListItem(
                    AppTextDisplay.PostStatusDraft,
                    ((int) PostStatus.Draft).ToString(),
                    status == PostStatus.Draft
                ),
                new SelectListItem(
                    AppTextDisplay.PostStatusPlanned,
                    ((int) PostStatus.Planned).ToString(),
                    status == PostStatus.Planned
                ),
                new SelectListItem(
                    AppTextDisplay.PostStatusPublished,
                    ((int) PostStatus.Published).ToString(),
                    status == PostStatus.Published
                )
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
    }
}
