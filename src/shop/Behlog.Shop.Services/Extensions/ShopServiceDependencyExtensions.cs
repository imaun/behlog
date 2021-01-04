using Behlog.Shop.Services.Data;
using Behlog.Shop.Services.Contracts;
using Behlog.Shop.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ShopServiceDependencyExtensions
    {

        public static void AddBehlogShopServices(this IServiceCollection services) {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services) {
            services.AddScoped<IProductService, ProductService>();
            ShopMappingConfig.AddShopDtoMappingConfig();
        }


    }
}
