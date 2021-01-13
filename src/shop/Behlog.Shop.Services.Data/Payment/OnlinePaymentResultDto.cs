using System;
using Behlog.Core.Models.Enum;

namespace Behlog.Shop.Services.Data {

    public class OnlinePaymentResultDto {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerTitle { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PayDate { get; set; }
        public PaymentStatus Status { get; set; }
        public string CallbackUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
