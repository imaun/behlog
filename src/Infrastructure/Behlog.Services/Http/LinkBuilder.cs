using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Behlog.Services.Contracts.Http;
using Behlog.Core.Extensions;

namespace Behlog.Services.Http {

    public class LinkBuilder: ILinkBuilder {

        private readonly IUrlHelper _urlHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LinkBuilder(IHttpContextAccessor httpContextAccessor) {
            httpContextAccessor.CheckArgumentIsNull(nameof(httpContextAccessor));
            _httpContextAccessor = httpContextAccessor;
            _urlHelper = _httpContextAccessor.HttpContext
                .RequestServices.GetService<IUrlHelper>();
        }

        public string BuildFromRoute(string routeName, object routeValues) =>
            _urlHelper.RouteUrl(routeName, routeValues);

        public bool UrlIsValid(string url) =>
            Uri.TryCreate(url, UriKind.Absolute, out _);
        
    }
}
