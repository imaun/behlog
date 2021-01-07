using System;
using System.Collections.Generic;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Services.Dto.Content;

namespace Behlog.Shop.Services.Data {

    public class ProductResultDto {
        
        public ProductResultDto() {
            Models = new List<ProductModelDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public PostBodyType BodyType { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public bool Orderable { get; set; }
        public bool AvailableForPreOrder { get; set; }
        public DateTime? PreOrderStartDate { get; set; }
        public DateTime? PreOrderFinishDate { get; set; }
        public ProductStatus Status { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string UnitName { get; set; }
        public decimal TaxAmount { get; set; }
        public bool NewProduct { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int OrderNumber { get; set; }
        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }
        public int? VendorId { get; set; }
        public string VendorTitle { get; set; }
        public string VendorSlug { get; set; }
        public int? BrandId { get; set; }
        public string BrandTitle { get; set; }
        public string BrandSlug { get; set; }
        public IEnumerable<ProductModelDto> Models { get; set; }
    }

    public class ProductPageDto: ProductResultDto { 

        public PostResultDto Post { get; set; }
        public IEnumerable<ProductModelDto> AvailableModels { get; set; }
        public IEnumerable<ShippingResultDto> ShippingMethods { get; set; }
        public IEnumerable<ProductMetaResultDto> Meta { get; set; }
    }
}
