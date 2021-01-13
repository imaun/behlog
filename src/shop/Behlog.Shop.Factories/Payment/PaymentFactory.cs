using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Behlog.Core.Extensions;
using Behlog.Core.Exceptions;
using Behlog.Core.Models.Shop;
using Behlog.Core.Models.Enum;
using Behlog.Shop.Services.Data;
using Behlog.Shop.Factories.Contracts;
using Behlog.Core.Contracts.Repository.Shop;
using Behlog.Core.Contracts.Services.Common;

namespace Behlog.Shop.Factories {

    public class PaymentFactory : IPaymentFactory {

        private readonly IDateService _dateService;
        private readonly ICustomerRepository _customerRepository;

        public PaymentFactory(
            IDateService dateService,
            ICustomerRepository customerRepository) {
            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;

            customerRepository.CheckArgumentIsNull(nameof(customerRepository));
            _customerRepository = customerRepository;
        }

        /// <inheritdoc/>
        public async Task<Payment> BuildOnlinePaymentAsync(CreateOnlinePaymentDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var customer = await _customerRepository.FindAsync(model.CustomerId);
            if (customer == null)
                throw new CustomerNotFoundException();

            var result = new Payment {
                Amount = model.Amount,
                CallbackUrl = model.CallbackUrl,
                CreateDate = _dateService.UtcNow(),
                CustomerId = model.CustomerId,
                CustomerTitle = customer.FullName,
                Description = model.Description,
                GatewayUrl = model.GatewayUrl,
                Method = PaymentMethod.Online,
                ModifyDate = _dateService.UtcNow(),
                PayDate = _dateService.UtcNow(),
                Status = PaymentStatus.Created,
                Paid = false
            };

            return await Task.FromResult(result);
        }
    }
}
