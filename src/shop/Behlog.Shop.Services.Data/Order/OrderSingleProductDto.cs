using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Shop.Services.Data {

    public class OrderSingleProductDto {
        public int ProductId { get; set; }
        public int? SelectedProductModelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
        public CreateShippingAddressDto ShippingAddress { get; set; }
    }

    public class OrderSingleProductResultDto
    {

    }
}
