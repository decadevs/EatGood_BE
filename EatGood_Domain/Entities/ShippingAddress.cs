namespace EatGood_Domain.Entities
{
    public class ShippingAddress
    {
        public string AppUserId { get; set; } = string.Empty;
        public required Address Address { get; set; }
    }
}
