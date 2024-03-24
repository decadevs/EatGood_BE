namespace EatGood_Domain.Entities
{
    public class OrderItem: BaseEntity
    {      
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public FoodItem FoodItem { get; set; }
        public string FoodItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } = 0;
    }
}
