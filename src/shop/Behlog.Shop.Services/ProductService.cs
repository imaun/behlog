using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Shop.Services.Contracts;
using Behlog.Core.Contracts.Repository.Shop;
using Behlog.Shop.Services.Data;
using Behlog.Services.Contracts.Content;
using Mapster;

namespace Behlog.Shop.Services
{
    public class ProductService: IProductService {

        private readonly IProductRepository _productRepository;
        private readonly IProductMetaRepository _metaRepository;

        public ProductService(
            IProductRepository productRepository,
            IProductMetaRepository metaRepository) {
            productRepository.CheckArgumentIsNull(nameof(productRepository));
            _productRepository = productRepository;

            metaRepository.CheckArgumentIsNull(nameof(metaRepository));
            _metaRepository = metaRepository;
        }
        
        public async Task<ProductResultDto> GetResultByIdAsync(int id) {
            var product = await _productRepository.GetByIdAsync(id);
            product.CheckReferenceIsNull($"Product with id: '{id}' not found.");

            return await Task.FromResult(
                product.Adapt<ProductResultDto>()
            );
        }


    }
}
