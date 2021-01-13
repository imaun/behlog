using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Shop.Services.Data.Payment {

    public class OnlinePaymentResultDto {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerTitle { get; set; }
        public decimal Amount { get; set; }

    }
}
