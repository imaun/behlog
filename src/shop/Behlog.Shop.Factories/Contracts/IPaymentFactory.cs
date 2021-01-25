using System.Threading.Tasks;
using Behlog.Core.Models.Shop;
using Behlog.Core.Models.Enum;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Factories.Contracts {

    public interface IPaymentFactory {

        /// <summary>
        /// Creates an Online <see cref="Payment"/> that user gonna pay it via
        /// an online gateway.
        /// </summary>
        /// <param name="model">Payment's data</param>
        /// <returns><see cref="Payment"/> entity</returns>
        Task<Payment> BuildOnlinePaymentAsync(CreateOnlinePaymentDto model);

        void SetStatus(Payment payment,
            bool succeded,
            bool fullyPaid = false,
            bool paidButHasRemain = false);

        void SetStatus(Payment payment, PaymentStatus status);

        void SetTransactionId(Payment payment, string transactionId);

        void Modified(Payment payment);

    }
}
