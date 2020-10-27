using System;
using System.Security.Claims;
using Behlog.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace Behlog.Core.Security
{
    public interface IUserContext
    {
        bool IsAuthenticated { get; }
        Guid UserId { get; }
        int WebsiteId { get; set; }
        string UserTitle { get; }
    }

    public class UserContext: IUserContext {

        public UserContext(IHttpContextAccessor httpContextAccessor) {
            httpContextAccessor.CheckArgumentIsNull();

            Principal = httpContextAccessor.HttpContext?.User;
            IsAuthenticated = Principal?.Identity.IsAuthenticated ?? false;

            if(IsAuthenticated)
                LoadData(httpContextAccessor.HttpContext);
        }

        protected virtual void LoadData(HttpContext httpContext) {
            UserId = Principal.Identity.GetUserId();
            UserTitle = Principal.Identity.GetUserFirstName();
            WebsiteId = Convert.ToInt32(Principal
                .Identity
                .GetUserWebsiteId()
            );
        }

        protected ClaimsPrincipal Principal { get; }
        public bool IsAuthenticated { get; }
        public Guid UserId { get; protected set; }
        public int WebsiteId { get; set; }
        public string UserTitle { get; protected set; }
    }
}
