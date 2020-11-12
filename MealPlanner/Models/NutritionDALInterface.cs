using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public interface NutritionDALInterface
    {
        public Task<FoodNutrition> GetFoodList(string keyword);
        public Task<FoodDetail> GetFoodDetail(int id);
    }
}
