using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Shop.Services.Contracts;
using Behlog.Shop.Services.Data;
using Behlog.Core.Contracts.Repository.Shop;
using Mapster;

namespace Behlog.Shop.Services {

    public class InvoiceService : IInvoiceService {

        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository) {
            invoiceRepository.CheckArgumentIsNull(nameof(invoiceRepository));
            _invoiceRepository = invoiceRepository;
        }

        public async Task<CustomerInvoiceDto> GetCustomerInvoiceAsync(int invoiceId) {
            var invoice = await _invoiceRepository.GetWithCustomerAsync(invoiceId);
            var result = new CustomerInvoiceDto {
                CreateDate = invoice.CreateDate,
                CustomerEmail = invoice.Customer.Email,
                CustomerFullName = invoice.Customer.FullName,
                CustomerId = invoice.CustomerId,
                CustomerMobile = invoice.Customer.Mobile,
                CustomerPostalCode =  invoice.ShippingAddress.PostalCode,
                CustomerShippingAddress = invoice.ShippingAddress.Address,
                InvoiceId = invoice.Id,
                TotalPrice = invoice.TotalPrice,
                UserId = invoice.Customer.UserId,
                Items = invoice.Orders.Adapt<List<CustomerInvoiceItemDto>>(),
                InvoiceStatus = invoice.Status
            };
            result.TotalTaxAmount = invoice.Orders.Sum(_ => _.TaxAmount);

            return await Task.FromResult(result);
        }
    }
}
