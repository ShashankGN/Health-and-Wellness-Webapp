namespace Spoonacular.API.DTO.ApiData
{
    public class RecipesPlanDayByTargetCalorieData
    {
        public Meals[] Meals { get; set; }
        public Nutrientss Nutrients { get; set; }
    }

    public class Nutrientss
    {
        public float calories { get; set; }
        public float protein { get; set; }
        public float fat { get; set; }
        public float carbohydrates { get; set; }
    }

    public class Meals
    {
        public int id { get; set; }
        public string imageType { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
    }

}
