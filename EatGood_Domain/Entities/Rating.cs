namespace EatGood_Domain.Entities
{
    public class Rating
    {
        public string AppUserId { get; set; } 
        public string VendorId { get; set; }
        public int FoodItemId { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
