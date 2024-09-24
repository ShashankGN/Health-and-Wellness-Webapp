using Microsoft.AspNetCore.WebUtilities;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Services
{
    public class RecipesPlanWeekByTargetCalorieClientService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpclient;

        public RecipesPlanWeekByTargetCalorieClientService(HttpClient httpclient, IConfiguration configuration)
        {
            _httpclient = httpclient;
            _configuration = configuration;
        }

        public async Task<RecipesPlanWeekByTargetCalorieData> GetRecipes(RecipesPlanWeekByTargetCalorieQueryParameter queryParameters)
        {
            var baseUrl = $"https://api.spoonacular.com/mealplanner/generate";

            var queryParams = new Dictionary<string, string>
            {
                { "apiKey", _configuration["ApiKey"] },
                { "timeFrame", queryParameters.TimeFrame?.ToString() },
                { "targetCalories", queryParameters.TargetCalories?.ToString() },
                { "diet", queryParameters.Diet?.ToString() },
                { "exclude", queryParameters.Exclude?.ToString() }
            }
            .Where(param => !string.IsNullOrEmpty(param.Value))
            .ToDictionary(param => param.Key, param => param.Value);

            var url = QueryHelpers.AddQueryString(baseUrl, queryParams);

            return await _httpclient.GetFromJsonAsync<RecipesPlanWeekByTargetCalorieData>(url);

        }
    }
}
