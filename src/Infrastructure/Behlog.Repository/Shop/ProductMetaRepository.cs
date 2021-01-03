using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {
    public class ProductMetaRepository: BaseRepository<ProductMeta, int>, IProductMetaRepository {

        public ProductMetaRepository(IBehlogContext context): base(context) {  }
    }
}
