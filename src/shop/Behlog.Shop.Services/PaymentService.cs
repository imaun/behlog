using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Behlog.Core.Extensions;
using Behlog.Core.Exceptions;
using Behlog.Shop.Services.Data;
using Behlog.Shop.Services.Contracts;
using Behlog.Shop.Services.Validation;
using Behlog.Shop.Factories.Contracts;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Shop.Services {

    public class PaymentService : IPaymentService {

        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentValidator _paymentValidator;
        private readonly IPaymentFactory _paymentFactory;

        public PaymentService(IPaymentRepository paymentRepository) {
            paymentRepository.CheckArgumentIsNull(nameof(paymentRepository));
            _paymentRepository = paymentRepository;
        }

        /// <inheritdoc/>
        public async Task CreateOnlinePaymentAsync(CreateOnlinePaymentDto model) {
            await _paymentValidator.ValidateCreateOnlinePaymentAsync(model);
            var payment = await _paymentFactory.BuildOnlinePaymentAsync(model);
            await _paymentRepository.AddAndSaveAsync(payment);

        }
    }
}
