using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {

    public class ProductModelRepository : BaseRepository<ProductModel, int>, IProductModelRepository {

        public ProductModelRepository(IBehlogContext context): base(context) { }

        public async Task<IEnumerable<ProductModel>> GetProductModelsAsync(
            int productId,
            ProductStatus? status = null) => status != null
                ? await _dbSet.Where(_ => _.ProductId == productId &&
                                        _.Status == status.Value)
                    .ToListAsync()
                : await _dbSet
                    .Where(_ => _.ProductId == productId)
                    .ToListAsync();

    }
}
