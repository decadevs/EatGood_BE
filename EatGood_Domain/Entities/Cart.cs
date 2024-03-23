namespace EatGood_Domain.Entities
{
    public class Cart: BaseEntity
    {
        public List<CartItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public ShippingDetails ShippingInfo { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
            TotalPrice = 0m;
            Tax = 0m;
            Subtotal = 0m;
            Discount = 0m;
            ShippingInfo = new ShippingDetails();
        }
    }
}
