using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Models.System;
using Behlog.Services.Dto.System;

namespace Behlog.Factories.Contracts.System
{
    public interface IWebsiteOptionFactory {

        Task<WebsiteOption> MakeAsync(CreateWebsiteOptionDto model);
        Task<IEnumerable<WebsiteOption>> MakeAsync(WebsiteOptionCategoryDto model);
    }
}
