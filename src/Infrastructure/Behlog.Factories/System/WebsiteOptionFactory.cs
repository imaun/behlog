using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Behlog.Factories.Contracts.System;
using Behlog.Services.Dto.System;
using Mapster;

namespace Behlog.Factories.System
{
    public class WebsiteOptionFactory: IWebsiteOptionFactory {

        private readonly IWebsiteInfo _websiteInfo;

        public WebsiteOptionFactory(IWebsiteInfo websiteInfo) {
            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;
        }

        public async Task<WebsiteOption> MakeAsync(CreateWebsiteOptionDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var entity = model.Adapt<WebsiteOption>();
            entity.WebsiteId = _websiteInfo.Id;

            return await Task.FromResult(
                entity);
        }

        public async Task<IEnumerable<WebsiteOption>> MakeAsync(WebsiteOptionCategoryDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var result = new List<WebsiteOption>();
            foreach (var item in model.Items)
                result.Add(new WebsiteOption {
                    LangId = model.LangId,
                    Category = model.Category,
                    WebsiteId = _websiteInfo.Id,
                    Key = item.Key,
                    OrderNum = item.OrderNum,
                    Status = EntityStatus.Enabled,
                    Title = item.Title,
                    Value = item.Value
                });

            return await Task.FromResult(
                result.ToList()
                );
        }
    }
}
