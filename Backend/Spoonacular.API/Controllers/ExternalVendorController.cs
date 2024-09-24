using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spoonacular.API.DTO.QueryParameter;
using Spoonacular.API.Queries;

namespace Spoonacular.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalVendorController : ControllerBase
    {
        ISender _sender;
        public ExternalVendorController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost("SearchRecipe")]
        public async Task<IActionResult> GetSearchRecipieData([FromBody] SearchRecipesQueryParameter queryParameters)
        {
            var result = await _sender.Send(new GetSearchRecipesDataQuery(queryParameters));
            return Ok(result);
        }

        [HttpPost("RecipeByNutrients")]
        public async Task<IActionResult> GetRecipieByNutrientsData([FromBody] NutrientsManagementQueryData queryParameters)
        {
            var result = await _sender.Send(new GetRecipesByNutrientsDataQuery(queryParameters));
            return Ok(result);
        }

        [HttpPost("RecipeWeekByTargetCalorie")]
        public async Task<IActionResult> GetRecipeWeekByTargetCalorieData([FromBody] RecipesPlanWeekByTargetCalorieQueryParameter queryParameters)
        {
            var result=await _sender.Send(new GetRecipesPlanWeekByTargetCalorieDataQuery(queryParameters));
            return Ok(result);
        }

        [HttpPost("RecipeDayByTargetCalorie")]
        public async Task<IActionResult> GetRecipeDayByTargetCalorieData([FromBody] RecipesPlanDayByTargetCalorieQueryParameter queryParameters)
        {
            var result = await _sender.Send(new GetRecipesPlanDayByTargetCalorieDataQuery(queryParameters));
            return Ok(result);
        }

        [HttpPost("Exercise")]
        public async Task<IActionResult> GetExerciseSuggestion([FromBody] ExerciseSuggestionQueryData queryParameters)
        {
            var result = await _sender.Send(new ExerciseSuggestionDataQuery(queryParameters));
            return Ok(result);
        }

        [HttpPost("CaloriesBurned")]
        public async Task<IActionResult> GetCaloriesBurned([FromBody] CaloriesBurnedQueryData queryParameters)
        {
            var result = await _sender.Send(new CaloriesBurnedDataQuery(queryParameters));
            return Ok(result);
        }

        [HttpPost("StoreCalories")]
        public async Task<IActionResult> PutGoalCalories([FromBody] CalBurnedQueryData queryParameters)
        {
            var result = await _sender.Send(new CaloriesManagementDataQuery(queryParameters));
            return Ok(result);
        }

        [HttpGet("GetRecord")]
        public async Task<IActionResult> GetRecords()
        {
            var result = await _sender.Send(new GetCaloriesBurnedDataQuery());
            return Ok(result);
        }
        [HttpPost("CaloriesGained")]
        public async Task<IActionResult> GetCaloriesGained(CaloriesGainedQueryData queryParameters)
        {
            var result = await _sender.Send(new CaloriesGainedDataQuery(queryParameters));
            return Ok(result);
        }
        [HttpPost("StoreCaloriesGained")]
        public async Task<IActionResult> PutCaloriesGained(CalGaiedQueryData queryParameters)
        {
            var result = await _sender.Send(new CaloriesGainedManagementDataQuery(queryParameters));
            return Ok(result);
        }
        [HttpGet("StoredGainCalories")]
        public async Task<IActionResult> GetStoredCalories()
        {
            var result = await _sender.Send(new GetCaloriesGainedDataQuery());
            return Ok(result);
        }

    }
}
