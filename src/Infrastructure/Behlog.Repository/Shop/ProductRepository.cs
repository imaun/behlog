using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {

    public class ProductRepository: BaseRepository<Product, int>, IProductRepository {

        public ProductRepository(IBehlogContext context): base(context) {  }
    }
}
