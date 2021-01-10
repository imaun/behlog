using System.Threading.Tasks;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Services.Contracts {

    public interface IOrderProductService {
        Task<CustomerBasketDto> OrderProductAsync(OrderSingleProductDto model);
    }
}
