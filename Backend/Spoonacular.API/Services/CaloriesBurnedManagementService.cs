using Microsoft.EntityFrameworkCore;
using Spoonacular.API.Data;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;
using Spoonacular.API.Model;
using System;

namespace Spoonacular.API.Services
{
    public class CaloriesBurnedManagementService
    {
        private readonly CostomerDbContext _context;
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public CaloriesBurnedManagementService(CostomerDbContext context, IHttpContextAccessor contextaccessor)
        {
            _context = context;
            _httpcontextAccessor = contextaccessor;
        }

        public User GetUserById(string id)
        {
            return _context.Users
                .Include(u => u.DailyBurntCalories)
                    .ThenInclude(d => d.Activities)
                .Include(u => u.WeeklyBurntCalories)
                    .ThenInclude(w => w.DailyRecords)
                .FirstOrDefault(u => u.UserId == id);
        }

        public async Task<bool> RecordCalories(CalBurnedQueryData calquery)
        {
            var id = _httpcontextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            var user = GetUserById(id);

            var currentDate = DateTime.UtcNow.Date;

            if (user == null || user.DailyBurntCalories.All(d => d.Date != currentDate))
            {
                if (calquery.TargetCalories == null)
                {
                    throw new Exception("Please provide your target calories goal.");
                }

                if (user == null)
                {
                    user = new User
                    {
                        UserId = id,
                        TargetBurntCalories = calquery.TargetCalories.Value,
                        DailyBurntCalories = new List<DailyBurntCalories>(),
                        WeeklyBurntCalories = new List<WeeklyBurntCalories>()
                    };
                    _context.Users.Add(user);
                }
                else
                {
                    user.TargetBurntCalories = calquery.TargetCalories.Value;
                }
            }

            var dailyCalories = user.DailyBurntCalories.FirstOrDefault(d => d.Date == currentDate);

            if (dailyCalories == null)
            {
                if (user.DailyBurntCalories.Count > 0)
                {
                    var lastDay = user.DailyBurntCalories.OrderByDescending(d => d.Date).First();
                    user.WeeklyBurntCalories.Add(new WeeklyBurntCalories
                    {
                        WeekStartDate = lastDay.Date,
                        TotalBurntCalories = lastDay.TotalBurntCalories,
                        DailyRecords = user.DailyBurntCalories.ToList()
                    });

                    user.DailyBurntCalories.Clear();
                }

                dailyCalories = new DailyBurntCalories
                {
                    Date = currentDate,
                    CaloriesGoal = user.TargetBurntCalories
                };
                user.DailyBurntCalories.Add(dailyCalories);
            }

            foreach (var activityInput in calquery.Activities)
            {
                dailyCalories.Activities.Add(new Activity
                {
                    Name = activityInput.Name,
                    BurntCalories = activityInput.BurntCalories,
                    HoursSpent = activityInput.HoursSpent
                });

                dailyCalories.TotalHourSpent += activityInput.HoursSpent;
                dailyCalories.TotalBurntCalories += activityInput.BurntCalories;
            }

            var percentage = (double)dailyCalories.TotalBurntCalories / user.TargetBurntCalories * 100;
            Save();
            return true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<CalBurnedData> GetRecord()
        {
            var id = _httpcontextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            var user = GetUserById(id);

            if (user == null)
            {
                return null;
            }

            var currentDate = DateTime.UtcNow.Date;

            var dailyCalories = user.DailyBurntCalories.FirstOrDefault(d => d.Date == currentDate);

            if(dailyCalories==null)
            {
                return null;
            }

            if (dailyCalories.TotalBurntCalories >= user.TargetBurntCalories)
            {
                return new CalBurnedData
                {
                    Message = "Congratulations! You've reached your goal.",
                    GoalCalories = user.TargetBurntCalories,
                    CaloriesBurnt = dailyCalories.TotalBurntCalories,
                    Percentage = 100,
                    Hours = dailyCalories.TotalHourSpent,
                    Activities = dailyCalories.Activities.Select(a => new ActivityData
                    {
                        Name = a.Name,
                        BurntCalories = a.BurntCalories,
                        HoursSpent = a.HoursSpent
                    }).ToList()
                };
            }

            var percentage = (double)dailyCalories.TotalBurntCalories / user.TargetBurntCalories * 100;

            return new CalBurnedData
            {
                Message = "Keep going!",
                Percentage = percentage,
                GoalCalories = user.TargetBurntCalories,
                CaloriesBurnt = dailyCalories.TotalBurntCalories,
                Hours = dailyCalories.TotalHourSpent,
                Activities = dailyCalories.Activities.Select(a => new ActivityData
                {
                    Name = a.Name,
                    BurntCalories = a.BurntCalories,
                    HoursSpent = a.HoursSpent
                }).ToList()
            };
        }
    }
}
