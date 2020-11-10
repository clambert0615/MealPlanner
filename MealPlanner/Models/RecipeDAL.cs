using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class RecipeDAL : RecipeDALInterface
    {
        public HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
            return client;
        }
        public async Task<Recipe> GetRecipes(string ingredient)
        {
            HttpClient client = GetClient();
            var response = await client.GetAsync($"filter.php?i={ingredient}");
            //Install-package Microsoft.AspNet.WebAPI.Client
            Recipe recipe = await response.Content.ReadAsAsync<Recipe>();
            return recipe;

        }
        public async Task<RecipeDetail> RecipeDetails(string id)
        {
            HttpClient client = GetClient();
            var response = await client.GetAsync($"lookup.php?i={id}");
            RecipeDetail recipe = await response.Content.ReadAsAsync<RecipeDetail>();
            return recipe;
        }
    }
}
