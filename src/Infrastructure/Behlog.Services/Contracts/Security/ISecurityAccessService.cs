using System.Security.Claims;

namespace Behlog.Services.Contracts.Security {
    public interface ISecurityAccessService {
        bool CanCurrentUserAccess(string area, 
            string controller, 
            string action);
        bool CanUserAccess(ClaimsPrincipal user, 
            string area, 
            string controller, 
            string action);
    }
}
