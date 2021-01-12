using Behlog.Core.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Behlog.Shop.Factories.Contracts
{
    public interface IInvoiceFactory
    {
        Task<Invoice> BuildInvoiceAndPayAsync(Basket basket);
    }
}
