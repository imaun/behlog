using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Models.System;
using Behlog.Services.Dto.System;

namespace Behlog.Factories.Contracts.System
{
    public interface IWebsiteFactory 
    {
        /// <summary>
        /// Create a fresh <see cref="Website"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Website> CreateAsync(WebsiteCreateDto model);
    }
}
