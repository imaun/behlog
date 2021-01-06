using System.Threading.Tasks;
using System.Collections.Generic;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Core.Contracts.Repository.Shop;
using Behlog.Shop.Services.Data;
using Mapster;

namespace Behlog.Shop.Services {

    public class ProductModelService {

        private readonly IProductModelRepository _productModelRepository;

        public ProductModelService(IProductModelRepository productModelRepository) {
            productModelRepository.CheckArgumentIsNull(nameof(productModelRepository));
            _productModelRepository = productModelRepository;
        }

        public async Task<IEnumerable<ProductModelDto>> GetAvailableModelsAsync(int productId) {
            return (await _productModelRepository
                    .GetProductModelsAsync(productId, ProductStatus.Enabled)
                ).Adapt<List<ProductModelDto>>();
        }
    }
}
