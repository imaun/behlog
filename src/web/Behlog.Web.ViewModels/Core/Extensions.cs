using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Core;
using Behlog.Core.Models.Enum;
using Behlog.Resources.Strings;
using Behlog.Web.ViewModels.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace Behlog.Web.ViewModels.Extensions
{
    public static class Extensions
    {
        internal static IServiceProvider _serviceProvider = null;

        public static void Configure(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public static GlobalViewData __ViewData =>
            _serviceProvider != null 
            ? _serviceProvider.GetRequiredService<GlobalViewData>()
            : null;

        public static string GetDefaultImagePath() =>
            __ViewData.DefaultImagePath.Replace("~", AppHttpContext.BaseUrl);
        
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

    }
}
