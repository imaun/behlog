using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Web.Shop.Data;
using Behlog.Web.Shop.ViewModels;
using Behlog.Shop.Services.Contracts;

namespace Behlog.Web.Shop.Components {

    public class OrderSingleProductViewComponent: ViewComponent {

        private readonly ShippingAddressDataProvider _shippingAddressDataProvider;
        private readonly IProductService _productService;

        public OrderSingleProductViewComponent(
            ShippingAddressDataProvider shippingAddressDataProvider,
            IProductService productService) {
            shippingAddressDataProvider.CheckArgumentIsNull(nameof(shippingAddressDataProvider));
            _shippingAddressDataProvider = shippingAddressDataProvider;

            productService.CheckArgumentIsNull(nameof(productService));
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId) {
            var product = await _productService.GetResultByIdAsync(productId);
            if (product == null)
                return await Task.FromResult(
                    Content(string.Empty)
                );

            var model = new OrderSingleProductViewModel {
                ProductId = productId,
                Title = product.Title,    
                ShippingAddress = await _shippingAddressDataProvider
                    .GetOrderNewShippingAddressAsync(),
            };

            return await Task.FromResult(View(model));
        }
    }
}
