namespace EatGood_Domain.Entities
{
    public class DeliveryStatus: BaseEntity
    {
        public int OrderId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime DeliveryDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; } = DateTime.Now;
    }
}
