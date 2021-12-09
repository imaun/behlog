using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Behlog.Web.Admin.Core
{
    public static class AdminRouteMiddleware
    {
        public static IApplicationBuilder UseAdminRoutes(this IApplicationBuilder app) {
            app.Use((ctx, next) => {
                if (ctx.Request.Path.HasValue) {
                    var slug = ctx.Request.Query["slug"].FirstOrDefault();
                    if (slug != null && slug.ToLower() == "admin") {
                        ctx.Response.Redirect("/Admin");
                    }
                }
                
                return next();
            });

            return app;
        }
    }
}
