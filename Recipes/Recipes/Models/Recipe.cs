using System;
using SQLite;

namespace Recipes.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
    }
}