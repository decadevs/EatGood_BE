﻿namespace EatGood_Domain.Entities
{
    public class ShippingDetails: BaseEntity
    {
        public string ShippingAddressId { get; set; }
        public ShippingAddress ShippingAddress { get; set; } 
        public string ShippingMethod { get; set; } = string.Empty;
        public DateTime EstimatedDeliveryDate { get; set; } = DateTime.Now;
    }
}
