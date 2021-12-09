using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Behlog.Core.Extensions;

namespace Behlog.Web.Common.Routing {

    public class BehlogReservedRouteConstraint : IRouteConstraint {

        public bool Match(HttpContext httpContext, 
            IRouter route, 
            string routeKey, 
            RouteValueDictionary values, 
            RouteDirection routeDirection
        ) {

            httpContext.CheckArgumentIsNull(nameof(httpContext));
            route.CheckArgumentIsNull(nameof(route));
            routeKey.CheckArgumentIsNull(nameof(routeKey));
            values.CheckArgumentIsNull(nameof(values));
            
            if(routeKey.ToLower() == "posttype" || 
                routeKey.ToLower() == "slug") {
                var value = values.GetValueOrDefault(routeKey);
                
                if (_ReservedWords.Contains(value.ToString().ToLower()))
                    return false;
            }

            return true;
        }

        private static List<string> _ReservedWords => new List<string> {
            "admin",
            "manage",
            "identity",
            "account",
            "login",
            "logout",
            "home",
            "index",
            "post",
            "contact",
            "search",
            "error",
            "pay",
            "order",
            "category",
            "shop",
            "verify"
        };
    }
}
