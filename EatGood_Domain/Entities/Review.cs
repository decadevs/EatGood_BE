namespace EatGood_Domain.Entities
{
    public class Review: BaseEntity
    {
        public string AppUserId { get; set; } 
        public string VendorId { get; set; }
        public int FoodItemId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } 
        public DateTime Date { get; set; }
    }
}
