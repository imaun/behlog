using System;
using System.Collections.Generic;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Web.ViewModels.Content;
using DNTPersianUtils.Core;

namespace Behlog.Web.Shop.ViewModels {

    public class ProductPageViewModel {

        public ProductPageViewModel() {
            Meta = new List<ProductMetaViewModel>();
            ShippingMethods = new List<ShippingViewModel>();
            AvailableModels = new List<ProductModelViewModel>();
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
        public string PreOrderStartDateDisplay => PreOrderStartDate?.ToPersianDateTextify();
        public DateTime? PreOrderFinishDate { get; set; }
        public string PreOrderFinishDateDisplay => PreOrderFinishDate?.ToPersianDateTextify();
        public ProductStatus Status { get; set; }
        public string StatusDisplay => Status.ToDisplay();
        public decimal Price { get; set; }
        public string PriceDisplay => $"{Price:N0}";
        public int Stock { get; set; }
        public string UnitName { get; set; }
        public decimal TaxAmount { get; set; }
        public string TaxAmountDisplay => $"{TaxAmount:N0}";
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
        public IEnumerable<ProductMetaViewModel> Meta { get; set; }
        public IEnumerable<ProductModelViewModel> AvailableModels { get; set; }
        public IEnumerable<ShippingViewModel> ShippingMethods { get; set; }
        public PostViewModel Post { get; set; }

    }
}
