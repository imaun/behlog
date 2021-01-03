using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {
    public class PaymentRepository: BaseRepository<Payment, int>, IPaymentRepository {

        public PaymentRepository(IBehlogContext context): base(context) {  }
    }
}
