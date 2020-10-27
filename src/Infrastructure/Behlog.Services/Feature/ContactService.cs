using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Contracts.Repository.Feature;
using Behlog.Core.Extensions;
using Behlog.Factories.Contracts.Feature;
using Behlog.Services.Contracts.Feature;
using Behlog.Services.Dto.Feature;
using Mapster;

namespace Behlog.Services.Feature
{
    public class ContactService: IContactService {

        private readonly IContactRepository _repository;
        private readonly IContactFactory _factory;

        public ContactService(
            IContactRepository repository,
            IContactFactory factory) {
            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;
        }

        public async Task<ContactResultDto> CreateAsync(CreateContactDto model) {
            var entity = await _factory.MakeAsync(model);
            await _repository.AddAndSaveAsync(entity);

            var result = entity.Adapt<ContactResultDto>();

            return await Task.FromResult(result);
        }
    }
}
