using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class NutritionDAL : NutritionDALInterface
    {
        private readonly string APIKey;
        public NutritionDAL(IConfiguration configuration)
        {
            APIKey = configuration.GetSection("ApiKeys")["FoodData"];
        }
        public HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.nal.usda.gov");
            return client;
        }

        public async Task<FoodNutrition> GetFoodList(string keyword)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = await client.GetAsync($"/fdc/v1/foods/search?api_key={APIKey}&query={keyword}");
            string json = await response.Content.ReadAsStringAsync();
            FoodNutrition foods = JsonConvert.DeserializeObject<FoodNutrition>(json);
            return foods;
        }
        public async Task<FoodDetail> GetFoodDetail(int id)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = await client.GetAsync($"/fdc/v1/food/{id}?api_key={APIKey}");
            string json = await response.Content.ReadAsStringAsync();
            FoodDetail food = JsonConvert.DeserializeObject<FoodDetail>(json);
            return food;
        }
    }
}
