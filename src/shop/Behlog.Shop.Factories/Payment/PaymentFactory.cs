using System.Threading.Tasks;
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
                Status = PaymentStatus.Created,
                Paid = false,
                InvoiceId = model.InvoiceId
            };

            return await Task.FromResult(result);
        }

        /// <inheritdoc/>
        public void SetStatus(Payment payment, PaymentStatus status)
            => payment.Status = status;

        /// <inheritdoc/>
        public void SetTransactionId(Payment payment, string transactionId) {
            if (transactionId != null) payment.TransactionId = transactionId;
        }

        /// <inheritdoc/>
        public void SetStatus(Payment payment, 
            bool succeded, 
            bool fullyPaid = false,
            bool paidButHasRemain = false) {

            if (!succeded) {
                payment.Status = PaymentStatus.Unsuccessful;
                return;
            }
            
            if (succeded && !fullyPaid && !paidButHasRemain) {
                payment.Status = PaymentStatus.Successful;
                SetPayDate(payment);
                return;
            }
            
            if (succeded && fullyPaid && !paidButHasRemain) {
                payment.Status = PaymentStatus.SuccessfulAndFullyPaid;
                SetPayDate(payment);
                return;
            }
            
            if (succeded && !fullyPaid && paidButHasRemain) {
                payment.Status = PaymentStatus.SuccessfulButHasRemaining;
                SetPayDate(payment);
                return;
            }
            
        }

        public void SetPayDate(Payment payment)
            => payment.PayDate = _dateService.UtcNow();

        public void Modified(Payment payment)
            => payment.ModifyDate = _dateService.UtcNow();
    }
}
