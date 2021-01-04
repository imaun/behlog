using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Shop.Services.Data
{
    public class ProductColor {
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
