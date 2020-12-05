using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Contracts.Repository.Feature;
using Behlog.Core.Extensions;
using Behlog.Core.Security;
using Behlog.Factories.Contracts.Feature;
using Behlog.Services.Contracts.Feature;
using Behlog.Services.Dto.Admin.Feature;
using Behlog.Services.Dto.Feature;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Behlog.Services.Extensions;
using Behlog.Core.Models.Feature;
using Behlog.Core.Models.Enum;

namespace Behlog.Services.Feature
{
    public class ContactService: IContactService {

        private readonly IContactRepository _repository;
        private readonly IContactFactory _factory;
        private readonly IUserContext _userContext;

        public ContactService(
            IContactRepository repository,
            IContactFactory factory,
            IUserContext userContext) {
            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;

            userContext.CheckArgumentIsNull(nameof(userContext));
            _userContext = userContext;
        }

        public async Task<ContactResultDto> CreateAsync(CreateContactDto model) {
            var entity = await _factory.MakeAsync(model);
            await _repository.AddAndSaveAsync(entity);

            var result = entity.Adapt<ContactResultDto>();

            return await Task.FromResult(result);
        }

        public async Task<AdminContactIndexDto> GetAdminIndexAsync(
            AdminContactIndexFilter filter) {
            filter.CheckArgumentIsNull(nameof(filter));

            var query = _repository
                .Query()
                .Where(_ => _.WebsiteId == _userContext.WebsiteId)
                .SetFilter(filter);

            var result = new AdminContactIndexDto();
            result.DataSource.TotalCount = await query.CountAsync();
            result.DataSource.PageIndex = filter.PageIndex;
            result.DataSource.PageSize = filter.PageSize;

            query = query
                .Skip(filter.StartIndex)
                .Take(filter.PageSize);

            var contacts = await query.ToListAsync();

            await setSentMessagesToViewed(contacts);
            await setViewedMessagesToRead(contacts);

            result.DataSource.Items = contacts
                .Select(_ => _.Adapt<AdminContactIndexItemDto>())
                .ToList();

            return await Task.FromResult(result);
        }


        private async Task setSentMessagesToViewed(IList<Contact> contacts) {
            foreach(var contact in contacts
                .Where(_=> _.Status == ContactMessageStatus.Sent)
            ) {
                contact.Status = ContactMessageStatus.Viewed;
                _repository.MarkForUpdate(contact);
            }

            await _repository.SaveChangesAsync();
        }

        private async Task setViewedMessagesToRead(IList<Contact> contacts) {
            foreach (var contact in contacts
                .Where(_ => _.Status == ContactMessageStatus.Viewed)
            ) {
                contact.Status = ContactMessageStatus.Read;
                _repository.MarkForUpdate(contact);
            }

            await _repository.SaveChangesAsync();
        }
    }
}
