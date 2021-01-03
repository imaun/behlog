using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop {

    public class OrderRepository: BaseRepository<Order, int>, IOrderRepository {

        public OrderRepository(IBehlogContext context): base(context) {  }
    }
}
