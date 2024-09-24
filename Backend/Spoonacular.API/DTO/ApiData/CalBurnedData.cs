namespace Spoonacular.API.DTO.ApiData
{
    public class ActivityData
    {
        public string Name { get; set; }
        public double BurntCalories { get; set; }
        public double HoursSpent { get; set; }
    }

    public class CalBurnedData
    {
        public string Message { get; set; }
        public double GoalCalories { get; set; }
        public double CaloriesBurnt { get; set; }
        public double Percentage { get; set; }
        public double Hours { get; set; }
        public List<ActivityData> Activities { get; set; }
    }

}