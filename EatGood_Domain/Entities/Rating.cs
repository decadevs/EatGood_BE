namespace EatGood_Domain.Entities
{
    public class Rating : BaseEntity
    {
        public string AppUserId { get; set; } 
        public string FoodItemId { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public AppUser AppUser { get; set; }
        public FoodItem FoodItem { get; set; }
    }
}
