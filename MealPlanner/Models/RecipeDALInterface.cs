using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public interface RecipeDALInterface
    {
        public Task<Recipe> GetRecipes(string ingredient);
        public Task<RecipeDetail> RecipeDetails(string id);
    }
}
