using System;
using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository.Feature;
using Behlog.Core.Exceptions;
using Behlog.Core.Extensions;
using Behlog.Services.Dto.Feature;
using Behlog.Validation.Contracts.Feature;

namespace Behlog.Validation.Feature
{
    public class SubscriberValidator : ISubscriberValidator
    {
        private readonly ISubscriberRepository _repository;

        public SubscriberValidator(ISubscriberRepository repository) {
            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;
        }

        public async Task<bool> ValidateCreateAsync(CreateSubscriberDto model) {
            model.CheckArgumentIsNull(nameof(model));

            //if (string.IsNullOrWhiteSpace(model.Name))
            //    throw new ArgumentNullException(nameof(model.Name));

            if (string.IsNullOrWhiteSpace(model.Email))
                throw new ArgumentNullException(nameof(model.Email));

            var subscriber = await _repository.FindByEmailAsync(model.Email);
            if (subscriber != null)
                throw new SubscriptionEmailExistException();

            return await Task.FromResult(true);
        }
    }
}

