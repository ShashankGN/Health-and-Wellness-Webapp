using Microsoft.EntityFrameworkCore;
using Spoonacular.API.Data;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;
using Spoonacular.API.Model;

namespace Spoonacular.API.Services
{
    public class CaloriesGainedManagementService
    {
        private readonly CostomerDbContext _context;
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public CaloriesGainedManagementService(CostomerDbContext context, IHttpContextAccessor contextaccessor)
        {
            _context = context;
            _httpcontextAccessor = contextaccessor;
        }

        public CalorieGainigUser GetUserById(string id)
        {
            return _context.CalorieGainigUsers
                .Include(u => u.DailyGainedCalories)
                    .ThenInclude(d => d.foodWithCalories)
                .Include(u => u.WeeklyGainedCalories)
                    .ThenInclude(w => w.DailyRecords)
                .FirstOrDefault(u => u.UserId == id);
        }

        public async Task<bool> RecordCaloriesGained(CalGaiedQueryData calquery)
        {
            var id = _httpcontextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            var user = GetUserById(id);
            var currentDate = DateTime.UtcNow.Date;

            if (user == null || user.DailyGainedCalories.All(d => d.Date != currentDate))
            {
                if (calquery.TargetCalories == null)
                {
                    throw new Exception("Please provide your target gained calories goal.");
                }

                if (user == null)
                {
                    user = new CalorieGainigUser
                    {
                        UserId = id,
                        TargetGainedCalories = calquery.TargetCalories.Value,
                        DailyGainedCalories = new List<DailyGainedCalories>(),
                        WeeklyGainedCalories = new List<WeeklyGainedCalories>()
                    };
                    _context.CalorieGainigUsers.Add(user);
                }
                else
                {
                    user.TargetGainedCalories = calquery.TargetCalories.Value;
                }
            }

            var dailyCalories = user.DailyGainedCalories.FirstOrDefault(d => d.Date == currentDate);

            if (dailyCalories == null)
            {
                if (user.DailyGainedCalories.Count > 0)
                {
                    var lastDay = user.DailyGainedCalories.OrderByDescending(d => d.Date).First();
                    user.WeeklyGainedCalories.Add(new WeeklyGainedCalories
                    {
                        WeekStartDate = lastDay.Date,
                        TotalGainedCalories = lastDay.TotalGainedCalories,
                        DailyRecords = user.DailyGainedCalories.ToList()
                    });

                    user.DailyGainedCalories.Clear();
                }

                dailyCalories = new DailyGainedCalories
                {
                    Date = currentDate,
                    GainedCaloriesGoal = user.TargetGainedCalories
                };
                user.DailyGainedCalories.Add(dailyCalories);
            }

            foreach (var foodInput in calquery.FoodItems)
            {
                dailyCalories.foodWithCalories.Add(new FoodWithCalorie
                {
                    Name = foodInput.Name,
                    GainedCalories = foodInput.GainedCalories
                });

                dailyCalories.TotalGainedCalories += foodInput.GainedCalories;
            }

            var percentage = (double)dailyCalories.TotalGainedCalories / user.TargetGainedCalories * 100;
            Save();
            return true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<CalGainedData> GetGainedRecord()
        {
            var id = _httpcontextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            var user = GetUserById(id);

            if (user == null)
            {
                return null;
            }

            var currentDate = DateTime.UtcNow.Date;

            var dailyCalories = user.DailyGainedCalories.FirstOrDefault(d => d.Date == currentDate);

            if (dailyCalories == null)
            {
                return null;
            }

            if (dailyCalories.TotalGainedCalories >= user.TargetGainedCalories)
            {
                return new CalGainedData
                {
                    Message = "Well done! You've met your calorie gain goal.",
                    GoalCalories = user.TargetGainedCalories,
                    CaloriesGained = dailyCalories.TotalGainedCalories,
                    Percentage = 100,
                    Foods = dailyCalories.foodWithCalories.Select(f => new FoodData
                    {
                        Name = f.Name,
                        GainedCalories = f.GainedCalories
                    }).ToList()
                };
            }

            var percentage = (double)dailyCalories.TotalGainedCalories / user.TargetGainedCalories * 100;

            return new CalGainedData
            {
                Message = "Keep consuming!",
                Percentage = percentage,
                GoalCalories = user.TargetGainedCalories,
                CaloriesGained = dailyCalories.TotalGainedCalories,
                Foods = dailyCalories.foodWithCalories.Select(f => new FoodData
                {
                    Name = f.Name,
                    GainedCalories = f.GainedCalories
                }).ToList()
            };
        }
    }
}

