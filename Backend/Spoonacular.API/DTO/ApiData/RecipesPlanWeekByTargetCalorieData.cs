namespace Spoonacular.API.DTO.ApiData
{


    public class RecipesPlanWeekByTargetCalorieData
    {
        public Week week { get; set; }
    }

    public class Week
    {
        public Monday monday { get; set; }
        public Tuesday tuesday { get; set; }
        public Wednesday wednesday { get; set; }
        public Thursday thursday { get; set; }
        public Friday friday { get; set; }
        public Saturday saturday { get; set; }
        public Sunday sunday { get; set; }
    }

    public class Monday
    {
        public Meal[] meals { get; set; }
        public Nutrients nutrients { get; set; }
    }

    public class Nutrients
    {
        public float calories { get; set; }
        public float protein { get; set; }
        public float fat { get; set; }
        public float carbohydrates { get; set; }
    }

    public class Meal
    {
        public int id { get; set; }
        public string imageType { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
    }

    public class Tuesday
    {
        public Meal1[] meals { get; set; }
        public Nutrients1 nutrients { get; set; }
    }

    public class Nutrients1
    {
        public float calories { get; set; }
        public float protein { get; set; }
        public float fat { get; set; }
        public float carbohydrates { get; set; }
    }

    public class Meal1
    {
        public int id { get; set; }
        public string imageType { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
    }

    public class Wednesday
    {
        public Meal2[] meals { get; set; }
        public Nutrients2 nutrients { get; set; }
    }

    public class Nutrients2
    {
        public float calories { get; set; }
        public float protein { get; set; }
        public float fat { get; set; }
        public float carbohydrates { get; set; }
    }

    public class Meal2
    {
        public int id { get; set; }
        public string imageType { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
    }

    public class Thursday
    {
        public Meal3[] meals { get; set; }
        public Nutrients3 nutrients { get; set; }
    }

    public class Nutrients3
    {
        public float calories { get; set; }
        public float protein { get; set; }
        public float fat { get; set; }
        public float carbohydrates { get; set; }
    }

    public class Meal3
    {
        public int id { get; set; }
        public string imageType { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
    }

    public class Friday
    {
        public Meal4[] meals { get; set; }
        public Nutrients4 nutrients { get; set; }
    }

    public class Nutrients4
    {
        public float calories { get; set; }
        public float protein { get; set; }
        public float fat { get; set; }
        public float carbohydrates { get; set; }
    }

    public class Meal4
    {
        public int id { get; set; }
        public string imageType { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
    }

    public class Saturday
    {
        public Meal5[] meals { get; set; }
        public Nutrients5 nutrients { get; set; }
    }

    public class Nutrients5
    {
        public float calories { get; set; }
        public float protein { get; set; }
        public float fat { get; set; }
        public float carbohydrates { get; set; }
    }

    public class Meal5
    {
        public int id { get; set; }
        public string imageType { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
    }

    public class Sunday
    {
        public Meal6[] meals { get; set; }
        public Nutrients6 nutrients { get; set; }
    }

    public class Nutrients6
    {
        public float calories { get; set; }
        public float protein { get; set; }
        public float fat { get; set; }
        public float carbohydrates { get; set; }
    }

    public class Meal6
    {
        public int id { get; set; }
        public string imageType { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
    }


}
