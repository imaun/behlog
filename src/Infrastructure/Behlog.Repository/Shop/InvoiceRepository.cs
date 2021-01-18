using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Repository.Shop
{
    public class InvoiceRepository: BaseRepository<Invoice, int>, IInvoiceRepository
    {

        public InvoiceRepository(IBehlogContext context): base(context) {  }

        public async Task<Invoice> GetWithCustomerAsync(int id)
            => await _dbSet
                .Include(_=> _.Orders)
                .Include(_ => _.Customer)
                .Include(_=> _.ShippingAddress)
                .FirstOrDefaultAsync(_ => _.Id == id);
    }
}
