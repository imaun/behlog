namespace Behlog.Web.Shop.ViewModels {

    public class ProductModelViewModel {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
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
        public bool NewModel { get; set; }
        public int? VendorId { get; set; }
        public string VendorTitle { get; set; }
    }

    public class ProductModelItemViewModel { 

    }
}
