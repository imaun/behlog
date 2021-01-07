using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Services.Contracts {

    public interface IProductModelService {

        Task<IEnumerable<ProductModelDto>> GetAvailableModelsAsync(int productId);
    }
}
