using System.Threading.Tasks;
using Behlog.Shop.Services.Data;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Shop;

namespace Behlog.Shop.Services.Contracts {

    public interface IProductService {

        Task<ProductResultDto> GetResultByIdAsync(int id);

        /// <summary>
        /// Get <see cref="Product"/> with it's available Models.
        /// Available Models is a <see cref="ProductModel"/> with it's status set to <see cref="ProductStatus.Enabled"/>................
        /// </summary>
        /// <param name="id">Product's Id</param>
        /// <returns>Product data with Available Models.</returns>
        Task<ProductResultDto> GetWithAvailableModelsAsync(int id);
    }
}
