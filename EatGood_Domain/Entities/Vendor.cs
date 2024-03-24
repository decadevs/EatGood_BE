using System.Net;

namespace EatGood_Domain.Entities
{
    public class Vendor: BaseEntity
    {
        public string AppUserId { get; set; }
        public string FoodItemId { get; set; }
        //public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        //public string Address { get; set; } = string.Empty;
        public List<FoodItem> Products { get; set; }
        public AppUser AppUser { get; set; }


    }
}
