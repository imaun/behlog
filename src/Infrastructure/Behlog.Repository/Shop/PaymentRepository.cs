using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {
    public class PaymentRepository: BaseRepository<Payment, int>, IPaymentRepository {

        public PaymentRepository(IBehlogContext context): base(context) {  }

        public async Task<Payment> GetWithInvoiceAsync(int id)
            => await _dbSet
                .Include(_ => _.Invoice)
                .FirstOrDefaultAsync(_ => _.Id == id);
    }
}
