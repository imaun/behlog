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
                .Where(_ => _.WebsiteId == _userContext.WebsiteId);

            var result = new AdminContactIndexDto();
            result.DataSource.TotalCount = await query.CountAsync();
            result.DataSource.PageIndex = filter.PageIndex;
            result.DataSource.PageSize = filter.PageSize;

            query = query.SetFilter(filter)
                .Skip(filter.StartIndex)
                .Take(filter.PageSize);

            result.DataSource.Items = await query
                .Select(_ => _.Adapt<AdminContactIndexItemDto>())
                .ToListAsync();

            return await Task.FromResult(result);
        }

    }
}
