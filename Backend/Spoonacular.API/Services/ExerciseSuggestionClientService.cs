using Microsoft.AspNetCore.WebUtilities;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Services
{
    public class ExerciseSuggestionClientService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpclient;

        public ExerciseSuggestionClientService(HttpClient httpclient, IConfiguration configuration)
        {
            _httpclient = httpclient;
            _configuration = configuration;
        }

        public async Task<List<ExerciseSuggetionData>> GetExerciseSuggestion(ExerciseSuggestionQueryData queryParameters)
        {
            var baseUrl = $"https://exercisedb.p.rapidapi.com/exercises/bodyPart/{queryParameters.BodyPart}";

            var queryParams = new Dictionary<string, string>
            {
                { "rapidapi-key", _configuration["rapidapi-key"] },
                { "limit", queryParameters.Number.ToString() },
            }
            .Where(param => !string.IsNullOrEmpty(param.Value))
            .ToDictionary(param => param.Key, param => param.Value);

            var url = QueryHelpers.AddQueryString(baseUrl, queryParams);

            return await _httpclient.GetFromJsonAsync<List<ExerciseSuggetionData>>(url);

        }
    }
}
