using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {

    public class ShippingAddressRepository: BaseRepository<ShippingAddress, int>, IShippingAddressRepository {

        public ShippingAddressRepository(IBehlogContext context): base(context) {  }
    }
}
