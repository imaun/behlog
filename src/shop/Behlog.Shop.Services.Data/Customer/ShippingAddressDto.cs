using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Shop.Services.Data
{
    public class CreateShippingAddressDto
    {
        public int CustomerId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
