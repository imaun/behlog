using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Web.Common.Extensions;

namespace Behlog.Web.Shop.ViewModels {

    public class InvoiceInfoViewModel {
        public string Company { get; set; }
        public string Logo { get; set; }
        public string LogoPath => Logo.GetFullImagePath();
        public string Address { get; set; }
        public string Phones { get; set; }
        public string Email { get; set; }
    }
}
