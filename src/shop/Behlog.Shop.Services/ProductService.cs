using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Shop.Services.Data;
using Behlog.Shop.Services.Contracts;
using Behlog.Core.Contracts.Repository.Shop;
using Mapster;

namespace Behlog.Shop.Services
{
    public class ProductService: IProductService {

        private readonly IProductRepository _productRepository;
        private readonly IProductMetaRepository _metaRepository;
        private readonly IProductModelRepository _productModelRepository;

        public ProductService(
            IProductRepository productRepository,
            IProductMetaRepository metaRepository,
            IProductModelRepository productModelRepository) {
            productRepository.CheckArgumentIsNull(nameof(productRepository));
            _productRepository = productRepository;

            metaRepository.CheckArgumentIsNull(nameof(metaRepository));
            _metaRepository = metaRepository;

            productModelRepository.CheckArgumentIsNull(nameof(productModelRepository));
            _productModelRepository = productModelRepository;
        }
        
        public async Task<ProductResultDto> GetResultByIdAsync(int id) {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return null;

            return await Task.FromResult(
                product.Adapt<ProductResultDto>()
            );
        }


        /// <inheritdoc/>
        public async Task<ProductResultDto> GetWithAvailableModelsAsync(int id) {
            var product = await _productRepository
                .GetWithModelsAsync(id, ProductStatus.Enabled);
            if (product == null)
                return null;

            return await Task.FromResult(
                product.Adapt<ProductResultDto>()
            );
        }

    }
}
