using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class FoodNutrition
    {
        public Foodsearchcriteria foodSearchCriteria { get; set; }
        public int totalHits { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }
        public Food[] foods { get; set; }
    }

    public class Foodsearchcriteria
    {
    }

    public class Food
    {
        public int fdcId { get; set; }
        public string dataType { get; set; }
        public string description { get; set; }
        public string foodCode { get; set; }
        public Foodnutrient[] foodNutrients { get; set; }
        public string publicationDate { get; set; }
        public string scientificName { get; set; }
        public string brandOwner { get; set; }
        public string gtinUpc { get; set; }
        public string ingredients { get; set; }
        public string ndbNumber { get; set; }
        public string additionalDescriptions { get; set; }
        public string allHighlightFields { get; set; }
        public double score { get; set; }
    }

 

    public class FoodDetail
    {
        public object[] foodComponents { get; set; }
        public object[] foodAttributes { get; set; }
        public object[] foodPortions { get; set; }
        public int fdcId { get; set; }
        public string description { get; set; }
        public string publicationDate { get; set; }
        public Foodnutrient[] foodNutrients { get; set; }
        public string dataType { get; set; }
        public string foodClass { get; set; }
        public string modifiedDate { get; set; }
        public string availableDate { get; set; }
        public string brandOwner { get; set; }
        public string dataSource { get; set; }
        public string brandedFoodCategory { get; set; }
        public string gtinUpc { get; set; }
        public string householdServingFullText { get; set; }
        public string ingredients { get; set; }
        public string marketCountry { get; set; }
        public float servingSize { get; set; }
        public string servingSizeUnit { get; set; }
        public Foodupdatelog[] foodUpdateLog { get; set; }
        public Labelnutrients labelNutrients { get; set; }
    }

    public class Labelnutrients
    {
        public Fat fat { get; set; }
        public Saturatedfat saturatedFat { get; set; }
        public Transfat transFat { get; set; }
        public Cholesterol cholesterol { get; set; }
        public Sodium sodium { get; set; }
        public Carbohydrates carbohydrates { get; set; }
        public Sugars sugars { get; set; }
        public Protein protein { get; set; }
        public Calories calories { get; set; }
    }

    public class Fat
    {
        public float value { get; set; }
    }

    public class Saturatedfat
    {
        public float value { get; set; }
    }

    public class Transfat
    {
        public float value { get; set; }
    }

    public class Cholesterol
    {
        public float value { get; set; }
    }

    public class Sodium
    {
        public float value { get; set; }
    }

    public class Carbohydrates
    {
        public float value { get; set; }
    }

    public class Sugars
    {
        public float value { get; set; }
    }

    public class Protein
    {
        public float value { get; set; }
    }

    public class Calories
    {
        public float value { get; set; }
    }

    public class Foodnutrient
    {
        public string type { get; set; }
        public Nutrient nutrient { get; set; }
        public Foodnutrientderivation foodNutrientDerivation { get; set; }
        public int id { get; set; }
        public float amount { get; set; }
    }

    public class Nutrient
    {
        public int id { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public int rank { get; set; }
        public string unitName { get; set; }
    }

    public class Foodnutrientderivation
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public Foodnutrientsource foodNutrientSource { get; set; }
    }

    public class Foodnutrientsource
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Foodupdatelog
    {
        public object[] foodAttributes { get; set; }
        public int fdcId { get; set; }
        public string description { get; set; }
        public string publicationDate { get; set; }
        public string dataType { get; set; }
        public string foodClass { get; set; }
        public string modifiedDate { get; set; }
        public string availableDate { get; set; }
        public string brandOwner { get; set; }
        public string dataSource { get; set; }
        public string brandedFoodCategory { get; set; }
        public string gtinUpc { get; set; }
        public string householdServingFullText { get; set; }
        public string ingredients { get; set; }
        public string marketCountry { get; set; }
        public float servingSize { get; set; }
        public string servingSizeUnit { get; set; }
    }

}
