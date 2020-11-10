using System;
using Microsoft.Extensions.DependencyInjection;
using Behlog.Core;
using Behlog.Web.Core.Settings;

namespace Behlog.Web.Common
{
    public static class CommonHelper
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
    }
}
