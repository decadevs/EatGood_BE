namespace EatGood_Domain.Entities
{
    public class Order: BaseEntity
    {
        public string AppUserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
