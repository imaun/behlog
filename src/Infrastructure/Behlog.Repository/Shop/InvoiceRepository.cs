using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop
{
    public class InvoiceRepository: BaseRepository<Invoice, int>, IInvoiceRepository
    {

        public InvoiceRepository(IBehlogContext context): base(context) {  }
    }
}
