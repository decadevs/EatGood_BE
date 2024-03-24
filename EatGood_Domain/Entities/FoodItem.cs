namespace EatGood_Domain.Entities
{
    public class FoodItem: BaseEntity
    {       
        public string Name { get; set; } 
        public string FoodCategoryId { get; set; }
        public string ReviewId { get; set; }
        public string RatingId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; } 
        public string ImageUrl { get; set; } 
        public FoodCategory Category { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Rating> Rating { get; set; }

    }
}
