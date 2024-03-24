namespace EatGood_Domain.Entities
{
    public class ShippingAddress : BaseEntity
    {
        public string AppUserId { get; set; } 
        public string Address { get; set; }

        public AppUser AppUser { get; set; }


    }
}
