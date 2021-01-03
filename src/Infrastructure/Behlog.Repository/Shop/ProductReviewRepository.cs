using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {

    public class ProductReviewRepository: BaseRepository<ProductReview, int>, IProductReviewRepository {

        public ProductReviewRepository(IBehlogContext context): base(context) { }
    }
}
