using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Shop.Services.Contracts { 
    
    public interface IPaymentService {

        Task CreateOnlinePaymentAsync();
    }
}
