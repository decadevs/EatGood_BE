namespace EatGood_Domain.Entities
{
    public class Order: BaseEntity
    {
        public string AppUserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string FoodItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } = 0;
        public  FoodItem FoodItem { get; set; }
        public AppUser AppUser { get; set; }
    }
}
