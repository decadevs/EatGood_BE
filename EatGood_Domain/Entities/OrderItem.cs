﻿namespace EatGood_Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FoodItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } = 0;
    }
}
