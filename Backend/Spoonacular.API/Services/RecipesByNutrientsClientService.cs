using Microsoft.AspNetCore.WebUtilities;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Services
{
    public class RecipesByNutrientsClientService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpclient;
        private readonly IHttpContextAccessor _httpcontextAccessor;
        private readonly CustomerNutrientsManagementService _customerNutrientsManagementService;

        public RecipesByNutrientsClientService(HttpClient httpclient, IConfiguration configuration, IHttpContextAccessor contextAccessor, CustomerNutrientsManagementService customerNutrientsManagementService)
        {
            _httpclient = httpclient;
            _configuration = configuration;
            _httpcontextAccessor = contextAccessor;
            _customerNutrientsManagementService = customerNutrientsManagementService;
        }

        public async Task<List<RecipesByNutrientsData>> GetRecipes(NutrientsManagementQueryData queryParameters)
        {
            SetQueryParametersFromClaims(queryParameters);

            var result = CustomerNutrientsManagementService.NutrientsCalculation(queryParameters);
            var queryParams = GenerateQueryParams(result, queryParameters);

            _customerNutrientsManagementService.NutrientsDbManager(result, queryParameters);

            var url = QueryHelpers.AddQueryString("https://api.spoonacular.com/recipes/findByNutrients", queryParams);

            return await _httpclient.GetFromJsonAsync<List<RecipesByNutrientsData>>(url);
        }

        private void SetQueryParametersFromClaims(NutrientsManagementQueryData queryParameters)
        {
            queryParameters.Gender = _httpcontextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "sex")?.Value;
            queryParameters.Age = int.Parse(_httpcontextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "age")?.Value);
            queryParameters.Id = _httpcontextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        }

        private Dictionary<string, string> GenerateQueryParams(NutrientsManagementData result, NutrientsManagementQueryData queryParameters)
        {
           
            var queryParams = new Dictionary<string, string>
            {
                { "apiKey", _configuration["ApiKey"] },
                
                { "minCarbs", result.BMI >= 25 ? null : result.CarbsPerMeal?.ToString() },
                { "maxCarbs", result.BMI >= 25 ? result.CarbsPerMeal?.ToString() : null },

                { "minProtein", result.BMI >= 25 ? null : result.ProteinPerMeal?.ToString() },
                { "maxProtein", result.BMI >= 25 ? result.ProteinPerMeal?.ToString() : null },

                { "minFiber", null }, 
                { "maxFiber",  result.BMI >= 25 ? result.FiberPerMeal?.ToString():null },

                { "minCalories", null }, 
                { "maxCalories",  result.BMI >= 25 ?result.Calories?.ToString():null },

                { "minFat", null }, 
                { "maxFat",  result.BMI >= 25 ? result.CarbsPerMeal?.ToString():null },

                {"random", true.ToString() },
                                
                { "number", queryParameters.Number.ToString() }
            };

            return queryParams.Where(param => !string.IsNullOrEmpty(param.Value))
                              .ToDictionary(param => param.Key, param => param.Value);
        }
    }
}
