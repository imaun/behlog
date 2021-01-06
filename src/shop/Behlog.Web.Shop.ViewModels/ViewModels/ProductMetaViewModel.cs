using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.Shop.ViewModels {
    
    public class ProductMetaViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public string Category { get; set; }
        public int? LangId { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string IconName { get; set; }
        public string CoverPhoto { get; set; }
        public int OrderNumber { get; set; }
    }

    public class ProductColorViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int Stock { get; set; }
        public decimal DiffPrice { get; set; }
        public string Photo { get; set; }
        public int OrderNumber { get; set; }
    }
}
