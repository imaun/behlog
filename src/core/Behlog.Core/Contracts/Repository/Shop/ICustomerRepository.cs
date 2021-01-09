using Behlog.Core.Models.Shop;
using System.Threading.Tasks;

namespace Behlog.Core.Contracts.Repository.Shop {
    public interface ICustomerRepository: IBaseRepository<Customer, int> {
        Task<Customer> GetByNationalCodeAsync(string nationalCode);
    }
}
