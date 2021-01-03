using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {

    public class ProductPriceRepository: BaseRepository<ProductPrice, int>, IProductPriceRepository {

        public ProductPriceRepository(IBehlogContext context): base(context) {  }
    }
}
