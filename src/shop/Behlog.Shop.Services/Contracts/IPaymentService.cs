using System.Threading.Tasks;
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

        Task VerifyFullPaymentAsync(
            int paymentId,
            string transactionId = null,
            string message = null,
            bool success = false);
    }
}
