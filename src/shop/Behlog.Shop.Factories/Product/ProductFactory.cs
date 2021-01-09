using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Models.Enum;
using Behlog.Core.Extensions;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Models.Shop;
using Behlog.Shop.Factories.Contracts;
using Behlog.Shop.Factories.Extensions;
using Behlog.Shop.Services.Data;

namespace Behlog.Shop.Factories
{
    public class ProductFactory : IProductFactory
    {
        private readonly IDateService _dateService;

        public ProductFactory(
            IDateService dateService) {
            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;
        }

        public async Task<Order> AddSingleOrderAsync(Product product, OrderSingleProductDto model) {
            var order = new Order {
                CreateDate = _dateService.UtcNow(),
                ModifyDate = _dateService.UtcNow(),
                ProductId = product.Id,
                ProductModelId = model.SelectedProductModelId,
                ProductTitle = product.Title,
                Quantity = model.Quantity,
                Status = InvoiceOrderStatus.Added,
                UnitPrice = product.Price,
                TaxAmount = product.TaxAmount,
                TaxPercent = product.TaxPercent,
                UnitName = product.UnitName,
                //DiscountPercent =  TODO: Get DiscountPercent from Price entity
                //DiscountValue  TODO : Get DiscountValue form Price entity
                TotalPrice = product.Price.Calculate(taxAmount: product.TaxAmount,
                                                    taxPercent: product.TaxPercent,
                                                    discountValue: 0,
                                                    discountPercent: null,
                                                    quantity: model.Quantity)
            };
            product.Orders.Add(order);

            return await Task.FromResult(order);
        }

    }
}
