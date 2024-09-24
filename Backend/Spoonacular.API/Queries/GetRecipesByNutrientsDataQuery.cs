using MediatR;
using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Queries
{
    public record GetRecipesByNutrientsDataQuery(NutrientsManagementQueryData queryParameter) : IRequest<List<RecipesByNutrientsData>>;

    public class GetRecipesByNutrientsDataQueryHandler : IRequestHandler<GetRecipesByNutrientsDataQuery, List<RecipesByNutrientsData>>
    {
        IExternalVendorRepository _externalVendorRepository;
        public GetRecipesByNutrientsDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository;
        }
        public async Task<List<RecipesByNutrientsData>> Handle(GetRecipesByNutrientsDataQuery request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.SearchtRecipesByNutrients(request.queryParameter);
        }
    }
}
