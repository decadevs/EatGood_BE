namespace EatGood_Domain.Entities
{
    public class DeliveryStatus: BaseEntity
    {
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string Status { get; set; } 
        public DateTime DeliveryDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; } = DateTime.Now;
    }
}
