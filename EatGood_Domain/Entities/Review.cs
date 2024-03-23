namespace EatGood_Domain.Entities
{
    public class Review: BaseEntity
    {
        public string AppUserId { get; set; } = string.Empty;
        public int FoodItemId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
