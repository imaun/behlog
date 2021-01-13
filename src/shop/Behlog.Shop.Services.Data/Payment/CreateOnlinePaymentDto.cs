using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Shop.Services.Data {

    public class CreateOnlinePaymentDto {
        public int? InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string GatewayUrl { get; set; }
        public string CallbackUrl { get; set; }
        public string Description { get; set; }
    }
}
