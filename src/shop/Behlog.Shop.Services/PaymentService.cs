using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Shop.Services.Data;
using Behlog.Shop.Services.Contracts;
using Behlog.Shop.Services.Validation;
using Behlog.Shop.Factories.Contracts;
using Behlog.Core.Contracts.Repository.Shop;
using Mapster;

namespace Behlog.Shop.Services {

    public class PaymentService : IPaymentService {

        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentValidator _paymentValidator;
        private readonly IPaymentFactory _paymentFactory;

        public PaymentService(
            IPaymentRepository paymentRepository,
            IPaymentValidator paymentValidator,
            IPaymentFactory paymentFactory) {
            paymentRepository.CheckArgumentIsNull(nameof(paymentRepository));
            _paymentRepository = paymentRepository;

            paymentValidator.CheckArgumentIsNull(nameof(paymentValidator));
            _paymentValidator = paymentValidator;

            paymentFactory.CheckArgumentIsNull(nameof(paymentFactory));
            _paymentFactory = paymentFactory;
        }

        /// <inheritdoc/>
        public async Task<OnlinePaymentResultDto> CreateOnlinePaymentAsync(
            CreateOnlinePaymentDto model) {
            await _paymentValidator.ValidateCreateOnlinePaymentAsync(model);
            var payment = await _paymentFactory.BuildOnlinePaymentAsync(model);
            await _paymentRepository.AddAndSaveAsync(payment);
            return await Task.FromResult(
                payment.Adapt<OnlinePaymentResultDto>()
            );
        }

        /// <inheritdoc/>
        public async Task VerifyFullPaymentAsync(
            int paymentId, 
            int? invoiceId = null,
            string transactionId = null, 
            string message = null,
            bool success = false) {
            var payment = await _paymentRepository.GetWithInvoiceAsync(paymentId);
            payment.CheckReferenceIsNull(nameof(payment));

            _paymentFactory.SetStatus(payment, success, fullyPaid: true);
            _paymentFactory.SetTransactionId(payment, transactionId);
            payment.Description = message;
            payment.InvoiceId = invoiceId;
            
            if(payment.InvoiceId.HasValue) {
                payment.Invoice.Status = InvoiceStatus.Paid;
            }

            await _paymentRepository.UpdateAndSaveAsync(payment);
        }

        /// <inheritdoc/>
        public async Task FailedAsync(int paymentId) {
            var payment = await _paymentRepository.FindAsync(paymentId);
            payment.CheckReferenceIsNull(nameof(payment));
            _paymentFactory.SetStatus(payment, PaymentStatus.Unsuccessful);
            _paymentFactory.Modified(payment);

            await _paymentRepository.UpdateAndSaveAsync(payment);
        }

    }
}
