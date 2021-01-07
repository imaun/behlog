using Behlog.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Shop.Services.Data
{
    public class ProductModelDto {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public string ColorValue { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CoverPhoto { get; set; }
        public int OrderNumber { get; set; }
        public bool Orderable { get; set; }
        public ProductStatus Status { get; set; }
        public bool NewModel { get; set; }
        public DateTime? NewModelStartDate { get; set; }
        public DateTime? NewModelFinishDate { get; set; }
        public int? VendorId { get; set; }
        public string VendorTitle { get; set; }
    }
}
