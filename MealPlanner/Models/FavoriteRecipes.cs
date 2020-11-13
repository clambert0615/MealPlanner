using System;
using System.Collections.Generic;

namespace MealPlanner.Models
{
    public partial class FavoriteRecipes
    {
        public int FavId { get; set; }
        public string RecipeId { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
