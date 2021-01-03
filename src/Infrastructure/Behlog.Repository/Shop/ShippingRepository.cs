using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {

    public class ShippingRepository: BaseRepository<Shipping, int>, IShippingRepository {

        public ShippingRepository(IBehlogContext context): base(context) { }
    }
}
