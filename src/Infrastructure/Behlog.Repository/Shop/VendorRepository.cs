using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {
    public class VendorRepository: BaseRepository<Vendor, int>, IVendorRepository {

        public VendorRepository(IBehlogContext context): base(context) {  }
    }
}
