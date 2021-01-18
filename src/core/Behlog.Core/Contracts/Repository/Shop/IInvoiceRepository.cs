using System.Threading.Tasks;
using Behlog.Core.Models.Shop;

namespace Behlog.Core.Contracts.Repository.Shop {
    public interface IInvoiceRepository: IBaseRepository<Invoice, int> {
        Task<Invoice> GetWithCustomerAsync(int id);
    }
}
