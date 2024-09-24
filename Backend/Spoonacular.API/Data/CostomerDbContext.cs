using Microsoft.EntityFrameworkCore;
using Spoonacular.API.Model;

namespace Spoonacular.API.Data
{
    public class CostomerDbContext:DbContext
    {
        public CostomerDbContext(DbContextOptions options):base(options) 
        {  
        }
        public DbSet<Costomer> customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DailyBurntCalories> DailyBurntCalories { get; set; }
        public DbSet<WeeklyBurntCalories> WeeklyBurntCalories { get; set; }
        public DbSet<CalorieGainigUser> CalorieGainigUsers { get; set; }
        public DbSet<DailyGainedCalories> DailyGainedCalories { get; set; }
        public DbSet<WeeklyGainedCalories> WeeklyGainedCalories { get; set; }
    }
}
