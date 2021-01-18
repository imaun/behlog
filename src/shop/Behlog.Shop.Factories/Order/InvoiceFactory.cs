using System.Linq;
using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Shop;
using Behlog.Shop.Factories.Contracts;

namespace Behlog.Shop.Factories {

    public class InvoiceFactory : IInvoiceFactory {

        //private readonly InvoiceRepository 
        private readonly IDateService _dateService;
        private readonly IWebsiteInfo _websiteInfo;

        public InvoiceFactory(IDateService dateService) {
            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;
        }

        public Invoice BuildInvoiceFromBasket(
            Basket basket,
            int shippingAddressId,
            int shippingId,
            InvoiceStatus status) {
            basket.CheckArgumentIsNull(nameof(basket));
            var invoice = new Invoice {
                CreateDate = _dateService.UtcNow(),
                CustomerId = basket.CustomerId,
                DueDate = _dateService.UtcNow(),
                ModifyDate = _dateService.UtcNow(),
                ShippingAddressId = shippingAddressId,
                ShippingId = shippingId,
                Status = status,
                WebsiteId = _websiteInfo.Id
            };

            foreach (var item in basket.Items) {
                invoice.Orders.Add(new Order {
                    CreateDate = _dateService.UtcNow(),
                    ModifyDate = _dateService.UtcNow(),
                    DiscountPercent = null, //Add DicsountPercent to BasketItem
                    DiscountValue = item.DiscountValue,
                    ProductId = item.ProductId,
                    ProductModelId = item.ProductModelId,
                    ProductModelTitle = item.ProductModelTitle,
                    ProductTitle = item.ProductTitle,
                    Quantity = item.Quantity,
                    ShippingAddressId = invoice.ShippingAddressId,
                    ShippingAmount = 0, //TODO 
                    ShippingId = invoice.ShippingId,
                    Status = status.GetOrderStatus(),
                    TaxAmount = item.TaxAmount,
                    TaxPercent = null, //TODO
                    TotalPrice = item.TotalPrice,
                    UnitName = item.UnitName,
                    UnitPrice = item.UnitPrice
                });
            }

            invoice.TotalPrice = invoice.Orders.Sum(_ => _.TotalPrice);

            return invoice;
        }

        public async Task<Invoice> BuildInvoiceAndPayAsync(Basket basket) {
            basket.CheckArgumentIsNull(nameof(basket));
            var invoice = new Invoice {
                CreateDate = _dateService.UtcNow(),
                CustomerId = basket.CustomerId,
                DueDate = _dateService.UtcNow(),
                ModifyDate = _dateService.UtcNow(),
                ShippingAddressId = 1, //TODO : Think about it from where??
                ShippingId = 1, //TODO : from where?
                Status = InvoiceStatus.Paid,
                WebsiteId = _websiteInfo.Id
            };

            foreach (var item in basket.Items) {
                invoice.Orders.Add(new Order {
                    CreateDate = _dateService.UtcNow(),
                    ModifyDate = _dateService.UtcNow(),
                    DiscountPercent = null, //Add DicsountPercent to BasketItem
                    DiscountValue = item.DiscountValue,
                    ProductId = item.ProductId,
                    ProductModelId = item.ProductModelId,
                    ProductModelTitle = item.ProductModelTitle,
                    ProductTitle = item.ProductTitle,
                    Quantity = item.Quantity,
                    ShippingAddressId = invoice.ShippingAddressId,
                    ShippingAmount = 0, //TODO 
                    ShippingId = invoice.ShippingId,
                    Status = InvoiceOrderStatus.Paid,
                    TaxAmount = item.TaxAmount,
                    TaxPercent = null, //TODO
                    TotalPrice = item.TotalPrice,
                    UnitName = item.UnitName,
                    UnitPrice = item.UnitPrice
                });
            }

            invoice.TotalPrice = invoice.Orders.Sum(_ => _.TotalPrice);

            //In online payments and from baskets you must create payment first 
            //if payment is successful then issue an invoice that is paid.
            var payment = new Payment {
                Amount = invoice.TotalPrice,
                CreateDate = _dateService.UtcNow(),
                ModifyDate = _dateService.UtcNow(),
                CustomerId = invoice.CustomerId,
                CustomerTitle = invoice.Customer.FullName, //TODO
                Method = PaymentMethod.Online,
                Paid = true,
                PayDate = _dateService.UtcNow(),
                Status = PaymentStatus.Successful
            };

            invoice.Payments.Add(payment);

            return await Task.FromResult(invoice);
        }

    }
}
