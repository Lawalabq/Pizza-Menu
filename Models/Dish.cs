﻿namespace WebApplication1.Models
{
    public class Dish
    {
        public int id { get; set; }
        public string name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        public List<DishIngredient>? DishIngredients { get; set; }
    }
}
