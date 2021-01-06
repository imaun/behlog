using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Shop;

namespace Behlog.Core.Contracts.Repository.Shop {

    public interface IProductModelRepository: IBaseRepository<ProductModel, int> {
        Task<IEnumerable<ProductModel>> GetProductModelsAsync(
            int productId, 
            ProductStatus? status = null);

    }
}
