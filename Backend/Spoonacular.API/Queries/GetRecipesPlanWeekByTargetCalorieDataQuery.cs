using MediatR;
using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Queries
{
    public record GetRecipesPlanWeekByTargetCalorieDataQuery(RecipesPlanWeekByTargetCalorieQueryParameter queryParameter):IRequest<RecipesPlanWeekByTargetCalorieData>;

    public class GetRecipesPlanWeekByTargetCalorieDataQueryHandler : IRequestHandler<GetRecipesPlanWeekByTargetCalorieDataQuery, RecipesPlanWeekByTargetCalorieData>
    {
        IExternalVendorRepository _externalVendorRepository;
        public GetRecipesPlanWeekByTargetCalorieDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository;
        }
        public async Task<RecipesPlanWeekByTargetCalorieData> Handle(GetRecipesPlanWeekByTargetCalorieDataQuery request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.SearchRecipesPlanWeekByTargetCalorie(request.queryParameter);
        }
    }

}
