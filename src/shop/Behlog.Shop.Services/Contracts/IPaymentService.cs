using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Services.Contracts { 
    
    public interface IPaymentService {

        /// <summary>
        /// Creates an Online <see cref="Payment"/> that user gonna pay it via
        /// an online gateway.
        /// </summary>
        /// <param name="model">Payments data to create.</param>
        /// <returns></returns>
        Task CreateOnlinePaymentAsync(CreateOnlinePaymentDto model);
    }
}
