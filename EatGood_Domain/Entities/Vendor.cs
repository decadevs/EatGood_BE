﻿using System.Net;

namespace EatGood_Domain.Entities
{
    public class Vendor: BaseEntity
    {
        public string AppUserId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string ContactEmail { get; set; } 
        public string ContactPhone { get; set; } 
        public string Address { get; set; } 
        public IEnumerable<FoodItem> FoodItems { get; set; }
        public IEnumerable<AppUser> Customers { get; set; }

       
    }
}
