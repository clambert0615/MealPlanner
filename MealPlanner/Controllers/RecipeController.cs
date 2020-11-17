using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MealPlanner.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult AddFavorite(string id, string name)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            FavoriteRecipes fav = new FavoriteRecipes { UserId = userid, RecipeId = id, RecipeName = name};
            if(_context.FavoriteRecipes.Where(x =>(x.UserId == userid) && (x.RecipeId == id)).ToList().Count > 0)
            {
                return RedirectToAction("ListFavorites");
            }
            if(ModelState.IsValid)
            {
                _context.FavoriteRecipes.Add(fav);
                _context.SaveChanges();
            }
            return RedirectToAction("ListFavorites");
        }
        [Authorize]
       public IActionResult ListFavorites()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<FavoriteRecipes> favList = _context.FavoriteRecipes.Where(x => x.UserId == userid).ToList();
            return View(favList);
        }
        [Authorize]
        public IActionResult RemoveFavorite(int id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            FavoriteRecipes fav = _context.FavoriteRecipes.FirstOrDefault(x => (x.UserId == userid) && (x.FavId == id));
            if(fav != null)
            {
                _context.FavoriteRecipes.Remove(fav);
                _context.SaveChanges();
            }
            return RedirectToAction("ListFavorites");
        }
    }
}
