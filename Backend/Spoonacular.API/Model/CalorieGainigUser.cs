using System.ComponentModel.DataAnnotations;

namespace Spoonacular.API.Model
{
    public class CalorieGainigUser
    {
        [Key]
        [Required]
        public string UserId { get; set; }
        public double TargetGainedCalories { get; set; }

        public List<DailyGainedCalories> DailyGainedCalories { get; set; } = new List<DailyGainedCalories>();

        public List<WeeklyGainedCalories> WeeklyGainedCalories { get; set; } = new List<WeeklyGainedCalories>();
    }
}
