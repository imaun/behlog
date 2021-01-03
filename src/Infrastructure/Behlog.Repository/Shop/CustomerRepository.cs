using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {
    public class CustomerRepository: BaseRepository<Customer, int>, ICustomerRepository {

        public CustomerRepository(IBehlogContext context): base(context) {  }

    }
}
