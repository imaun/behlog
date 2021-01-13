using System.Threading.Tasks;
using Behlog.Core.Models.Shop;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Services.Contracts { 
    
    public interface IPaymentService {

        /// <summary>
        /// Creates an Online <see cref="Payment"/> that user gonna pay it via
        /// an online gateway.
        /// </summary>
        /// <param name="model">Payments data to create.</param>
        /// <returns></returns>
        Task<OnlinePaymentResultDto> CreateOnlinePaymentAsync(CreateOnlinePaymentDto model);

        /// <summary>
        /// Verify <see cref="Payment"/> and set status based on <paramref name="success"/>
        /// </summary>
        /// <param name="paymentId">Id of Payment to verify</param>
        /// <param name="transactionId">The Bank ReferenceId for further uses.</param>
        /// <param name="message">The Payment Gateway message</param>
        /// <param name="success">pass True if payment gateway's status is success</param>
        /// <returns></returns>
        Task VerifyFullPaymentAsync(
            int paymentId,
            string transactionId = null,
            string message = null,
            bool success = false);
    }
}
