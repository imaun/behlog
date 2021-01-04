using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {

    public class ProductRepository: BaseRepository<Product, int>, IProductRepository {

        public ProductRepository(IBehlogContext context): base(context) {  }

        public async Task<Product> GetByIdAsync(int id)
            => await _dbSet
                .Include(_ => _.Category)
                .Include(_ => _.Brand)
                .Include(_ => _.Vendor)
                .FirstOrDefaultAsync(_ => _.Id == id);
    }
}
