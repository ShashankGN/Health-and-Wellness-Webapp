using MediatR;
using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Queries
{
    public record GetRecipesPlanDayByTargetCalorieDataQuery(RecipesPlanDayByTargetCalorieQueryParameter queryParameter) : IRequest<RecipesPlanDayByTargetCalorieData>;

    public class GetRecipesPlanDayByTargetCalorieDataQueryHandler : IRequestHandler<GetRecipesPlanDayByTargetCalorieDataQuery, RecipesPlanDayByTargetCalorieData>
    {
        IExternalVendorRepository _externalVendorRepository;
        public GetRecipesPlanDayByTargetCalorieDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository;
        }
        public async Task<RecipesPlanDayByTargetCalorieData> Handle(GetRecipesPlanDayByTargetCalorieDataQuery request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.SearchRecipesPlanDayByTargetCalorie(request.queryParameter);
        }
    }
}
