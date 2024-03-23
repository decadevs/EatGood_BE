namespace EatGood_Domain.Entities
{
    public class Rating
    {
        public string AppUserId { get; set; } = string.Empty;
        public int FoodItemId { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
