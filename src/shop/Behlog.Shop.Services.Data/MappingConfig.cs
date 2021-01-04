using Behlog.Core.Models.Shop;
using Mapster;

namespace Behlog.Shop.Services.Data {
    public static class ShopMappingConfig {

        public static void AddShopDtoMappingConfig() {
            TypeAdapterConfig<Product, ProductResultDto>
                .NewConfig()
                .Map(d => d.BrandSlug, s => s.Brand != null ? s.Brand.Slug : string.Empty)
                .Map(d => d.BrandTitle, s => s.Brand != null ? s.Brand.Title : string.Empty)
                .Map(d => d.CategoryTitle, s => s.Category != null ? s.Category.Title : string.Empty)
                .Map(d => d.VendorSlug, s => s.Vendor != null ? s.Vendor.Title : string.Empty);
        }
    }
}
