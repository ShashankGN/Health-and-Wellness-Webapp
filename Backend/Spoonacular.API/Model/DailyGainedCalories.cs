namespace Spoonacular.API.Model
{
    public class DailyGainedCalories
    {
        public int DailyGainedCaloriesId { get; set; }
        public DateTime Date { get; set; }
        public double GainedCaloriesGoal { get; set; }
        public double TotalGainedCalories { get; set; } = 0;
        public List<FoodWithCalorie> foodWithCalories { get; set; }= new List<FoodWithCalorie>();
    }
    public class FoodWithCalorie
    {
        public int FoodWithCalorieId { get; set; }
        public string Name { get; set; }
        public double GainedCalories { get; set; }
    }
}
