namespace Spoonacular.API.Model
{
    public class WeeklyGainedCalories
    {
        public int WeeklyGainedCaloriesId { get; set; }
        public DateTime WeekStartDate { get; set; }
        public double TotalGainedCalories { get; set; }
        public List<DailyGainedCalories> DailyRecords { get; set; } = new List<DailyGainedCalories>();
    }
}
