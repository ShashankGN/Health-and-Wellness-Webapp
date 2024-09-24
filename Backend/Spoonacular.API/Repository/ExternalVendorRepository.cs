using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;
using Spoonacular.API.Services;

namespace Spoonacular.API.Repository
{
    public class ExternalVendorRepository : IExternalVendorRepository
    {
        SearchRecipeClientService _searchRecipeClientService;
        RecipesByNutrientsClientService _recipesByNutrientsClientService;
        RecipesPlanWeekByTargetCalorieClientService _recipesPlanWeekByTargetCalorieClientService;
        RecipesPlanDayByTargetCalorieClientService _recipesPlanDayByTargetCalorieClientService;
        ExerciseSuggestionClientService _exerciseSuggestionClientService;
        CaloriesBurnedClientService _caloriesBurnedClientService;
        CaloriesBurnedManagementService _caloriesBurnedManagementService;
        CaloriesGainedClientService _caloriesGainedClientService;
        CaloriesGainedManagementService _caloriesGainedManagementService;
        public ExternalVendorRepository(SearchRecipeClientService searchRecipeClientService, 
            RecipesByNutrientsClientService recipesByNutrientsClientService,
            RecipesPlanWeekByTargetCalorieClientService recipesPlanWeekByTargetCalorieClientService, 
            RecipesPlanDayByTargetCalorieClientService recipesPlanDayByTargetCalorieClientService,
            ExerciseSuggestionClientService exerciseSuggestionClientService,
            CaloriesBurnedClientService caloriesBurnedClientService,
            CaloriesBurnedManagementService caloriesBurnedManagementService,
            CaloriesGainedClientService caloriesGainedClientService,
            CaloriesGainedManagementService caloriesGainedManagementService)
        {
            _searchRecipeClientService = searchRecipeClientService;
            _recipesByNutrientsClientService = recipesByNutrientsClientService;
            _recipesPlanWeekByTargetCalorieClientService = recipesPlanWeekByTargetCalorieClientService;
            _recipesPlanDayByTargetCalorieClientService = recipesPlanDayByTargetCalorieClientService;
            _exerciseSuggestionClientService = exerciseSuggestionClientService;
            _caloriesBurnedClientService = caloriesBurnedClientService;
            _caloriesBurnedManagementService= caloriesBurnedManagementService;
            _caloriesGainedClientService= caloriesGainedClientService;
            _caloriesGainedManagementService = caloriesGainedManagementService;
        }
        public Task<SearchRecipesData> SearchRecipes(SearchRecipesQueryParameter queryParameter)
        {
            return _searchRecipeClientService.GetRecipes(queryParameter);
        }

        public Task<List<RecipesByNutrientsData>> SearchtRecipesByNutrients(NutrientsManagementQueryData queryParameter)
        {
            return _recipesByNutrientsClientService.GetRecipes(queryParameter);
        }

        public Task<RecipesPlanWeekByTargetCalorieData> SearchRecipesPlanWeekByTargetCalorie(RecipesPlanWeekByTargetCalorieQueryParameter queryParameter)
        {
            return _recipesPlanWeekByTargetCalorieClientService.GetRecipes(queryParameter);
        }

        public Task<RecipesPlanDayByTargetCalorieData> SearchRecipesPlanDayByTargetCalorie(RecipesPlanDayByTargetCalorieQueryParameter queryParameter)
        {
            return _recipesPlanDayByTargetCalorieClientService.GetRecipes(queryParameter);
        }

        public Task<List<ExerciseSuggetionData>> SearchExerciseSuggestion(ExerciseSuggestionQueryData queryParameter)
        {
            return _exerciseSuggestionClientService.GetExerciseSuggestion(queryParameter);
        }
        public Task<List<CaloriesBurnedData>> SearchCaloriesBurned(CaloriesBurnedQueryData queryParameter)
        {
            return _caloriesBurnedClientService.GetCaloriesBurned(queryParameter);
        }
        public Task<bool> AddCaloriesBurned(CalBurnedQueryData queryParameter)
        {
            return _caloriesBurnedManagementService.RecordCalories(queryParameter);
        }
        public Task<CalBurnedData> GetCaloriesBurned()
        {
            return _caloriesBurnedManagementService.GetRecord();
        }
        public Task<double> SearchCaloriesGained(CaloriesGainedQueryData queryData)
        {
            return _caloriesGainedClientService.SearchCaloriesGained(queryData);
        }
        public Task<bool> AddCaloriesGained(CalGaiedQueryData queryData)
        {
            return _caloriesGainedManagementService.RecordCaloriesGained(queryData);
        }
        public Task<CalGainedData> GetCaloriesGained()
        {
            return _caloriesGainedManagementService.GetGainedRecord();
        }

    }
}
