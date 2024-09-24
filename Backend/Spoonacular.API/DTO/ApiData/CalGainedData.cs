namespace Spoonacular.API.DTO.ApiData
{
    public class FoodData
    {
        public string Name { get; set; }
        public double GainedCalories { get; set; }
    }

    public class CalGainedData
    {
        public string Message { get; set; }
        public double GoalCalories { get; set; }
        public double CaloriesGained { get; set; }
        public double Percentage { get; set; }
        public List<FoodData> Foods { get; set; }
    }
}
