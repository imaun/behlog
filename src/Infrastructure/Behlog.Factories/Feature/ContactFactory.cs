using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Feature;
using Behlog.Factories.Contracts.Feature;
using Behlog.Services.Dto.Feature;
using Behlog.Core.Models.Enum;
using Mapster;

namespace Behlog.Factories.Feature
{
    public class ContactFactory: IContactFactory {
        
        private readonly IDateService _dateService;
        private readonly IWebsiteInfo _websiteInfo;

        public ContactFactory(
            IDateService dateService,
            IWebsiteInfo websiteInfo) {
            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;
        }

        public async Task<Contact> MakeAsync(CreateContactDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var result = model.Adapt<Contact>();
            result.WebsiteId = _websiteInfo.Id;
            result.Ip = AppHttpContext.IpAddress; //AppHttpContext.Current.Connection.RemoteIpAddress?.ToString();
            result.UserAgent = AppHttpContext.UserAgent; //AppHttpContext.Request.Headers["User-Agent"][0];
            result.SessionId = AppHttpContext.SessionId; //AppHttpContext.Current.Session.Id;
            result.SentDate = _dateService.UtcNow();
            result.Status = ContactMessageStatus.Sent;

            return await Task.FromResult(result);
        }

        public Contact MarkAsViewed(Contact contact) {
            contact.Status = ContactMessageStatus.Viewed;
            return contact;
        }

        public Contact MarkAsRead(Contact contact) {
            contact.Status = ContactMessageStatus.Read;
            contact.ReadDate = _dateService.Now();
            return contact;
        }

    }
}
