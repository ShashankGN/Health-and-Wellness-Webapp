namespace Spoonacular.API.Model
{
    public class WeeklyBurntCalories
    {
        public int WeeklyBurntCaloriesId { get; set; }
        public DateTime WeekStartDate { get; set; }
        public double TotalBurntCalories { get; set; }
        public List<DailyBurntCalories> DailyRecords { get; set; } = new List<DailyBurntCalories>();
    }

}
