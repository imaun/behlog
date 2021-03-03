using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Models.System;

namespace Behlog.Core.Contracts.Repository.System
{
    public interface IMenuRepository: IBaseRepository<Menu, int> {
        Task<IEnumerable<Menu>> GetByWebsiteAsync(
            int websiteId,
            string lang = null);

        Task<IEnumerable<Menu>> GetEnabledByWebsiteAsync(
            int websiteId,
            string lang = null);
    }
}
