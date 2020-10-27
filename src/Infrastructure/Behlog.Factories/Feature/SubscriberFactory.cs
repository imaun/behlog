using Behlog.Core;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Feature;
using Behlog.Factories.Contracts.Feature;
using Behlog.Services.Dto.Feature;
using Behlog.Core.Models.Enum;
using System.Threading.Tasks;

namespace Behlog.Factories.Feature
{
    public class SubscriberFactory : ISubscriberFactory
    {
        private readonly IWebsiteInfo _websiteInfo;
        private readonly IDateService _dateService;

        public SubscriberFactory(
            IWebsiteInfo websiteInfo,
            IDateService dateService) {

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;

            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;
        }

        public async Task<Subscriber> MakeAsync(CreateSubscriberDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var entity = new Subscriber {
                Email = model.Email,
                Name = model.Name,
                RegisterDate = _dateService.UtcNow(),
                Status = SubscriberStatus.Enabled,
                WebsiteId = _websiteInfo.Id
            };

            return await Task.FromResult(entity);
        }
    }
}
