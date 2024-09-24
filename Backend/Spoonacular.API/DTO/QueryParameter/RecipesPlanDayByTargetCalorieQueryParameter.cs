﻿namespace Spoonacular.API.DTO.QueryParameter
{
    public class RecipesPlanDayByTargetCalorieQueryParameter
    {
        public string? TimeFrame { get; set; }
        public double? TargetCalories { get; set; }
        public string? Diet { get; set; }
        public string? Exclude { get; set; }
    }
}
