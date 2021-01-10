using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Web.Shop.Data;
using Behlog.Web.Shop.ViewModels;
using Behlog.Shop.Services.Contracts;
using Behlog.Web.Shop.Data.Extensions;
using Mapster;

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
            var product = await _productService
                .GetWithAvailableModelsAsync(productId);

            if (product == null)
                return await Task.FromResult(
                    Content(string.Empty)
                );

            var model = new OrderSingleProductViewModel {
                ProductId = productId,
                Price = product.Price,
                Title = product.Title,
                ShippingAddress = await _shippingAddressDataProvider
                    .GetOrderNewShippingAddressAsync(),
                AvailableModels = product.Models.Adapt<List<ProductModelViewModel>>()
            };
            model.AvailableModelsSource = model.AvailableModels
                .ToSelectListItems();

            return await Task.FromResult(View(model));
        }
    }
}
