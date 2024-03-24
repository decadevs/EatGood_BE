namespace EatGood_Domain.Entities
{
    public class ShippingAddress
    {
        public string AppUserId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
