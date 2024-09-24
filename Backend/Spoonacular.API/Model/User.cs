using System.ComponentModel.DataAnnotations;

namespace Spoonacular.API.Model
{
    public class User
    {
        [Key]
        [Required]
        public string UserId { get; set; }
        public double TargetBurntCalories { get; set; }

        public List<DailyBurntCalories> DailyBurntCalories { get; set; } = new List<DailyBurntCalories>();

        public List<WeeklyBurntCalories> WeeklyBurntCalories { get; set; } = new List<WeeklyBurntCalories>();
    }
}
