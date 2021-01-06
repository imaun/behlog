using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.Shop.ViewModels {
    
    public class OrderSingleProductViewModel {

        public OrderSingleProductViewModel() {
            ShippingAddress = new OrderNewShippingAddressViewModel();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
        public OrderNewShippingAddressViewModel ShippingAddress { get; set; }

    }
}
