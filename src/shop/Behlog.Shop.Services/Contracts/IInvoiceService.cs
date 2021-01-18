using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Services.Contracts
{
    public interface IInvoiceService
    {
        Task<CustomerInvoiceDto> GetCustomerInvoiceAsync(int invoiceId);
    }
}
