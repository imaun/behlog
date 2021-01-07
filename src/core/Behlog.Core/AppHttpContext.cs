using System;
using System.Linq;
using Behlog.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Behlog.Core {

    public static class AppHttpContext {

        private const string __USER_AGENT_KEY = "User-Agent";
        private const string __URL_REFERER = "Referer";

        private static IHttpContextAccessor _httpContext;

        public static HttpContext Current => _httpContext.HttpContext;
        public static HttpRequest Request => Current.Request;
        public static string BaseUrl => $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
        internal static void Configure(
            IHttpContextAccessor httpContext 
        ) {
            httpContext.CheckArgumentIsNull(nameof(httpContext));
            _httpContext = httpContext;
        }

        public static string UserAgent {
            get {
                return Request.Headers[__USER_AGENT_KEY][0];
                //return _detection.Browser.Name;
            }
        }

        public static string OsPlatform {
            get {
                return "Windows x64";
            }
        }

        public static string SessionId =>
            Current.Session.Id;

        public static string IpAddress =>
            Current.Connection.RemoteIpAddress?.ToString();

        public static string AbsoluteUrl {
            get {
                UriBuilder uriBuilder = new UriBuilder {
                    Scheme = Request.Scheme,
                    Host = Request.Host.Host,
                    Path = Request.Path.ToString(),
                    Query = Request.QueryString.ToString()
                };

                return uriBuilder.Uri.AbsoluteUri;
            }
        }

        public static string UrlReferer =>
            Request.Headers[__URL_REFERER].Any()
            ? Request.Headers[__URL_REFERER].ToString()
            : null;

        #region Helper Methods

        #endregion
    }

    public static class HttpContextExtensions
    {
        public static IApplicationBuilder UseAppHttpContext(this IApplicationBuilder app) {
            AppHttpContext.Configure(
                app.ApplicationServices.GetRequiredService<IHttpContextAccessor>()
            );
            return app;
        }

        //public static IApplicationBuilder MapBehlogStaticFiles(this IApplicationBuilder app) {
        //    app.MapWhen(context => {
        //        var path = context.Request.Path.Value.ToLower();
        //        return
        //            path.StartsWith("/assets") ||
        //            path.StartsWith("/lib") ||
        //            path.StartsWith("/themes") ||
        //            path.StartsWith("/app_data") ||
        //            path.StartsWith("/images") ||
        //            path.StartsWith("/uploads") ||
        //            path.StartsWith("/favicon") ||
        //            path.StartsWith("/fonts") ||
        //            path.StartsWith("/js") ||
        //            path.EndsWith("html") ||
        //            path.EndsWith("htm") ||
        //            path.EndsWith("robots.txt") ||
        //            path.StartsWith("/css");
        //    }, config => config.UseStaticFiles());
        //}
    }

    
}
