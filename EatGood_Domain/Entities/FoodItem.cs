namespace EatGood_Domain.Entities
{
    public class FoodItem : BaseEntity
    {
       // public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string FoodCategoryId { get; set; }
        public FoodCategory Category { get; set; }

    }
}
