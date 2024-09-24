using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Contracts
{
    public interface IExternalVendorRepository
    {
        Task<SearchRecipesData> SearchRecipes(SearchRecipesQueryParameter queryParameter);
        Task<List<RecipesByNutrientsData>> SearchtRecipesByNutrients(NutrientsManagementQueryData queryParameter);
        Task<RecipesPlanWeekByTargetCalorieData> SearchRecipesPlanWeekByTargetCalorie(RecipesPlanWeekByTargetCalorieQueryParameter queryParameter);
        Task<RecipesPlanDayByTargetCalorieData> SearchRecipesPlanDayByTargetCalorie(RecipesPlanDayByTargetCalorieQueryParameter queryParameter);
        Task<List<ExerciseSuggetionData>> SearchExerciseSuggestion(ExerciseSuggestionQueryData queryParameter);
        Task<List<CaloriesBurnedData>> SearchCaloriesBurned(CaloriesBurnedQueryData queryParameter);
        Task<bool> AddCaloriesBurned(CalBurnedQueryData queryParameter);
        Task<CalBurnedData> GetCaloriesBurned();
        Task<double> SearchCaloriesGained(CaloriesGainedQueryData queryData);
        Task<bool> AddCaloriesGained(CalGaiedQueryData queryData);
        Task<CalGainedData> GetCaloriesGained();
    }
}
