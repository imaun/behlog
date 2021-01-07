using Behlog.Shop.Services.Data;
using Behlog.Shop.Services.Contracts;
using Behlog.Web.Shop.Data;
using Behlog.Shop.Services;

namespace Microsoft.Extensions.DependencyInjection {

    public static class ShopServiceDependencyExtensions {

        /// <summary>
        /// Add all Behlog Shop module Services and Dependencies.
        /// </summary>
        /// <param name="services"></param>
        public static void AddBehlogShopServices(this IServiceCollection services) {
            services.AddServices();
            services.AddDataProviders();
        }

        private static void AddServices(this IServiceCollection services) {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductModelService, ProductModelService>();
            ShopMappingConfig.AddShopDtoMappingConfig();
        }

        private static void AddDataProviders(this IServiceCollection services) {
            services.AddScoped<ProductModelDataProvider>();
            services.AddScoped<ShippingAddressDataProvider>();

        }

    }
}
