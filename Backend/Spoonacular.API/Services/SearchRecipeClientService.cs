using Microsoft.AspNetCore.WebUtilities;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Services
{
    public class SearchRecipeClientService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpclient;

        public SearchRecipeClientService(HttpClient httpclient, IConfiguration configuration)
        {
            _httpclient = httpclient;
            _configuration = configuration;
        }
        public async Task<SearchRecipesData> GetRecipes(SearchRecipesQueryParameter queryParameters)
        {
            var baseUrl = $"https://api.spoonacular.com/recipes/complexSearch";

            var queryParams = new Dictionary<string, string>
            {
                { "apiKey", _configuration["ApiKey"] },
                { "query", queryParameters.Query },
                { "cuisine", queryParameters.Cuisine },
                { "excludeCuisine", queryParameters.ExcludeCuisine },
                { "diet", queryParameters.Diet },
                { "type", queryParameters.Type },
                { "sort", queryParameters.Sort },
                { "minCarbs", queryParameters.MinCarbs?.ToString() },
                { "maxCarbs", queryParameters.MaxCarbs?.ToString() },
                { "minCalories", queryParameters.MinCalories?.ToString() },
                { "maxCalories", queryParameters.MaxCalories?.ToString() },
                { "minFat", queryParameters.MinFat?.ToString() },
                { "maxFat", queryParameters.MaxFat?.ToString() },
                { "number", queryParameters.Number.ToString() }  
            }
            .Where(param => !string.IsNullOrEmpty(param.Value)) 
            .ToDictionary(param => param.Key, param => param.Value);


            var url = QueryHelpers.AddQueryString(baseUrl, queryParams);

            return await _httpclient.GetFromJsonAsync<SearchRecipesData>(url);
        }
    }
}
