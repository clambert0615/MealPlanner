using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Controllers
{
    public class NutritionController : Controller
    {
        private readonly NutritionDALInterface _nutdalint;
        public NutritionController(NutritionDALInterface nutdalint)
        {
            _nutdalint = nutdalint;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetFoods(string food)
        {
            
            FoodNutrition foods = await _nutdalint.GetFoodList(food);
            return View(foods);

        }
        public async Task<IActionResult> FoodDetails(int id)
        {
            FoodDetail fd = await _nutdalint.GetFoodDetail(id);
            return View(fd);
        }
    }
}
