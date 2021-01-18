using Behlog.Core.Models.Shop;
using System.Threading.Tasks;

namespace Behlog.Core.Contracts.Repository.Shop {
    public interface IPaymentRepository: IBaseRepository<Payment, int> {
        Task<Payment> GetWithInvoiceAsync(int id);
    }
}
