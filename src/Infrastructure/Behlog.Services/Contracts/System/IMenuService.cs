using System.Threading.Tasks;
using Behlog.Services.Dto.System;

namespace Behlog.Services.Contracts.System
{
    public interface IMenuService {
        Task<WebsiteMenuDto> GetWebsiteMenuAsync(string lang = null);
    }
}
