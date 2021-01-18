using Behlog.Shop.Services.Data;
using Behlog.Shop.Services.Contracts;
using Behlog.Web.Shop.Data;
using Behlog.Shop.Services;
using Behlog.Shop.Services.Validation;
using Behlog.Shop.Factories.Contracts;
using Behlog.Shop.Factories;

namespace Microsoft.Extensions.DependencyInjection {

    public static class ShopServiceDependencyExtensions {

        /// <summary>
        /// Add all Behlog Shop module Services and Dependencies.
        /// </summary>
        /// <param name="services"></param>
        public static void AddBehlogShopServices(this IServiceCollection services) {
            services.AddValidators();
            services.AddFactories();
            services.AddServices();
            services.AddDataProviders();
            
        }

        private static void AddServices(this IServiceCollection services) {
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IOrderProductService, OrderProductService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductModelService, ProductModelService>();
            services.AddScoped<IProductModelService, ProductModelService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShippingService, ShippingService>();
            ShopMappingConfig.AddShopDtoMappingConfig();
        }

        private static void AddValidators(this IServiceCollection services) {
            services.AddScoped<ICustomerValidator, CustomerValidator>();
            services.AddScoped<IPaymentValidator, PaymentValidator>();
        }

        private static void AddFactories(this IServiceCollection services) {
            services.AddScoped<ICustomerFactory, CustomerFactory>();
            services.AddScoped<IInvoiceFactory, InvoiceFactory>();
            services.AddScoped<IPaymentFactory, PaymentFactory>();
            services.AddScoped<IProductFactory, ProductFactory>();
            services.AddScoped<IShippingAddressFactory, ShippingAddressFactory>();
        }

        private static void AddDataProviders(this IServiceCollection services) {
            services.AddScoped<ProductModelDataProvider>();
            services.AddScoped<ShippingAddressDataProvider>();

        }

    }
}
