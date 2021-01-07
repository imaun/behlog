using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;
using Behlog.Core.Models.Enum;

namespace Behlog.Repository.Shop {

    public class ProductRepository: BaseRepository<Product, int>, IProductRepository {

        public ProductRepository(IBehlogContext context): base(context) {  }

        public async Task<Product> GetByIdAsync(int id)
            => await _dbSet
                .Include(_ => _.Category)
                .Include(_ => _.Brand)
                .Include(_ => _.Vendor)
                .FirstOrDefaultAsync(_ => _.Id == id);

        public async Task<Product> GetWithModelsAsync(int id, ProductStatus? modelStatus = null) {
            var product = await Query()
                .Include(_ => _.Category)
                .Include(_ => _.Brand)
                .Include(_ => _.Vendor)
                .Include(_ => _.Models)
                .FirstOrDefaultAsync(_ => _.Id == id);

            if (modelStatus.HasValue)
                filterModelsByStatus(product, modelStatus.Value);

            return product;
        }

        private void filterModelsByStatus(Product product, ProductStatus status)
            => product.Models.Where(_ => _.Status == status);
    }
}
