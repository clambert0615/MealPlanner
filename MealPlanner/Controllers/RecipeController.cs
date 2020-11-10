using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Controllers
{
    public class RecipeController : Controller
    {
        private readonly MealPlannerDbContext _context;
        private readonly RecipeDALInterface _recapi;
        public RecipeController(MealPlannerDbContext context, RecipeDALInterface recapi)
        {
            _context = context;
            _recapi = recapi;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> RecipeList(string ingredient)
        {
            Recipe recipes = await _recapi.GetRecipes(ingredient);
            return View(recipes);

        }
        public async Task<IActionResult> Details(string id)
        {
            RecipeDetail recipe = await _recapi.RecipeDetails(id);
            return View(recipe);
        }
    }
}
