using System;
using Behlog.Core.Models.Enum;

namespace Behlog.Shop.Services.Data {

    public class ShippingResultDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsFree { get; set; }
        public int MinDeliveryDays { get; set; }
        public int MaxDeliveryDays { get; set; }
        public EntityStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}
