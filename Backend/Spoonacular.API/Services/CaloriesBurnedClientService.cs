using Microsoft.AspNetCore.WebUtilities;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Services
{
    public class CaloriesBurnedClientService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpclient;

        public CaloriesBurnedClientService(HttpClient httpclient, IConfiguration configuration)
        {
            _httpclient = httpclient;
            _configuration = configuration;
        }

        public async Task<List<CaloriesBurnedData>> GetCaloriesBurned(CaloriesBurnedQueryData queryParameters)
        {
            var baseUrl = $"https://api.api-ninjas.com/v1/caloriesburned";

            var queryParams = new Dictionary<string, string>
            {
                { "X-Api-Key", _configuration["ninja-key"] },
                { "activity", queryParameters.Activity.ToString() },
            }
            .Where(param => !string.IsNullOrEmpty(param.Value))
            .ToDictionary(param => param.Key, param => param.Value);

            var url = QueryHelpers.AddQueryString(baseUrl, queryParams);

            return await _httpclient.GetFromJsonAsync<List<CaloriesBurnedData>>(url);

        }

    }
}
