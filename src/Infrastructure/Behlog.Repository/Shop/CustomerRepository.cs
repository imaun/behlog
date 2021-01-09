using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;
using System.Threading.Tasks;

namespace Behlog.Repository.Shop {
    public class CustomerRepository: BaseRepository<Customer, int>, ICustomerRepository {

        public CustomerRepository(IBehlogContext context): base(context) {  }

        public async Task<Customer> GetByNationalCodeAsync(string nationalCode)
            => await FirstOrDefaultAsync(_ => _.NationalCode == nationalCode);
    }
}
