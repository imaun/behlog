using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Behlog.Core.Extensions;
using Behlog.Services.Contracts.Feature;

namespace Behlog.Web.Common.Middlewares {

    public class WebsiteVisitCounterMiddleware {

        private readonly RequestDelegate _requestDelegate;
        private readonly IWebsiteVisitService _websiteVisitService;

        public WebsiteVisitCounterMiddleware(RequestDelegate requestDelegate,
            IWebsiteVisitService websiteVisitService) {

            requestDelegate.CheckArgumentIsNull(nameof(requestDelegate));
            _requestDelegate = requestDelegate;

            websiteVisitService.CheckArgumentIsNull(nameof(websiteVisitService));
            _websiteVisitService = websiteVisitService;
        }

        public async Task Invoke(HttpContext context) {

            var path = context.Request.Path;
            var pathSegments = path.Value.Split('/');

            if (pathSegments.Contains("admin")) {
                await _requestDelegate(context);
                return;
            }
            
            string visitorId = context.Request.Cookies["VisitorId"];

            if (visitorId == null) {
                await _websiteVisitService.CreateAsync();
                context.Response.Cookies.Append("VisitorId",
                    Guid.NewGuid().ToString(),
                    new CookieOptions {
                        Path = "/",
                        HttpOnly = true,
                        Secure = false,
                        Expires = DateTime.Now.AddHours(1)
                    });
            }

            await _requestDelegate(context);
        }

    }
}
