namespace EatGood_Domain.Entities
{
    public class Cart: BaseEntity
    {
        public List<FoodItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public ShippingDetails ShippingInfo { get; set; }

        
    }
}
