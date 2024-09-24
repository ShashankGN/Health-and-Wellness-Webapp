using Microsoft.AspNetCore.WebUtilities;
using Spoonacular.API.DTO.QueryParameter;
using System.Text.Json;

namespace Spoonacular.API.Services
{
    public class CaloriesGainedClientService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpclient;

        public CaloriesGainedClientService(HttpClient httpclient, IConfiguration configuration)
        {
            _httpclient = httpclient;
            _configuration = configuration;
        }

        public async Task<double> SearchCaloriesGained(CaloriesGainedQueryData queryData)
        {
            var baseUrl = $"https://api.edamam.com/api/nutrition-data";

            var queryParams = new Dictionary<string, string>
            {
                {"app_id", _configuration["app_id"]},
                {"app_key", _configuration["app_key"]},
                {"nutrition-type", "cooking"},
                {"ingr", queryData.Ingredient}
            };

            var url = QueryHelpers.AddQueryString(baseUrl, queryParams);

            var response = await _httpclient.GetStringAsync(url);

            var jsonDoc = JsonDocument.Parse(response);

            if (jsonDoc.RootElement.TryGetProperty("calories", out JsonElement caloriesElement))
            {
                return caloriesElement.GetDouble();
            }

            return 0;
        }
    }
}
