using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository.Feature;
using Behlog.Core.Extensions;
using Behlog.Factories.Contracts.Feature;
using Behlog.Services.Contracts.Feature;
using Behlog.Services.Dto.Feature;
using Behlog.Validation.Contracts.Feature;

namespace Behlog.Services.Feature
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberFactory _factory;
        private readonly ISubscriberRepository _repository;
        private readonly ISubscriberValidator _validator;

        public SubscriberService(
            ISubscriberFactory factory,
            ISubscriberRepository repository,
            ISubscriberValidator validator) {

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;

            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            validator.CheckArgumentIsNull(nameof(validator));
            _validator = validator;
        }

        public async Task CreateAsync(CreateSubscriberDto model) {
            var isValid = await _validator.ValidateCreateAsync(model);
            if (isValid) {
                var subscriber = await _factory.MakeAsync(model);
                await _repository.AddAndSaveAsync(subscriber);
            }
        }

    }
}
