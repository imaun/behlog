using System.Threading.Tasks;
using Behlog.Core.Models.Shop;
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
    }
}
