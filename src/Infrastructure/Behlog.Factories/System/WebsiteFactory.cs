using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Extensions;
using Behlog.Core.Models.System;
using Behlog.Factories.Contracts.System;
using Behlog.Services.Dto.System;
using Mapster;

namespace Behlog.Factories.System
{
    public class WebsiteFactory: IWebsiteFactory {

        private readonly IDateService _dateSvc;

        public WebsiteFactory(IDateService dateSvc) {
            dateSvc.CheckArgumentIsNull();
            _dateSvc = dateSvc;
        }


        public async Task<Website> CreateAsync(WebsiteCreateDto model) {
            var website = model.Adapt<Website>();
            website.CreateDate = website.ModifyDate = _dateSvc.UtcNow();
            
            return await Task.FromResult(website);
        }
    }
}
