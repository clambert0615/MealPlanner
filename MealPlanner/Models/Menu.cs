using System;
using System.Collections.Generic;

namespace MealPlanner.Models
{
    public partial class Menu
    {
        public int ItemId { get; set; }
        public string UserId { get; set; }
        public string Item { get; set; }
        public string Meal { get; set; }
        public DateTime? MealDate { get; set; }
        public int? Quantity { get; set; }
        public int? Calories { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
