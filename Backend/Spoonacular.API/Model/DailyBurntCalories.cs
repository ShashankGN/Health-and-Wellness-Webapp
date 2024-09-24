namespace Spoonacular.API.Model
{
    public class DailyBurntCalories
    {
        public int DailyBurntCaloriesId { get; set; }
        public DateTime Date { get; set; }
        public double TotalBurntCalories { get; set; } = 0;
        public double TotalHourSpent { get; set; } = 0;
        public double CaloriesGoal { get; set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
    }

    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; } 
        public double BurntCalories { get; set; } 
        public double HoursSpent { get; set; }
    }


}
