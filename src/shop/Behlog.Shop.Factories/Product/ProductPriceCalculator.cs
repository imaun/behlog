using System;
using System.Collections.Generic;
using System.Linq;
using Behlog.Core.Models.Shop;

namespace Behlog.Shop.Factories.Extensions
{
    public static class ProductPriceCalculator {

        public static decimal Calculate(
            this decimal price, 
            decimal taxAmount = 0, 
            decimal? taxPercent = null,
            decimal discountValue = 0,
            decimal? discountPercent = null,
            int quantity = 1) {
            
            decimal totoalPrice = price + taxAmount;
            if (taxPercent.HasValue)
                totoalPrice += (taxPercent.Value / 100) * totoalPrice;

            totoalPrice -= discountValue;
            if (discountPercent.HasValue)
                totoalPrice -= (discountPercent.Value / 100) * totoalPrice;

            return totoalPrice * quantity;
        }

        public static decimal CalculateTaxAmount(
            this decimal taxAmount,
            decimal totoalPrice,
            decimal? taxPercent = null) {
            if (taxPercent.HasValue)
                return taxAmount + ((taxPercent.Value / 100) * totoalPrice);
            return totoalPrice + taxAmount;
        }

        public static decimal CalculateTotalPrice(this IEnumerable<Order> orders)
            => orders.Sum(_ => _.TotalPrice);

        public static decimal CalculateTotalPrice(this IEnumerable<BasketItem> items)
            => items.Sum(_ => _.TotalPrice);

        public static decimal CalculateTotalTaxAmount(this IEnumerable<BasketItem> items)
            => items.Sum(_ => _.TaxAmount);
    }
}
