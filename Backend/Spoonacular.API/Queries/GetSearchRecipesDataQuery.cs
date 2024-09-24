using MediatR;
using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Queries
{
    public record GetSearchRecipesDataQuery(SearchRecipesQueryParameter queryParameter):IRequest<SearchRecipesData>;

    public class GetSearchRecipesDataQueryHandler : IRequestHandler<GetSearchRecipesDataQuery, SearchRecipesData>
    {
        IExternalVendorRepository _externalVendorRepository;
        public GetSearchRecipesDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository;
        }
        public async Task<SearchRecipesData> Handle(GetSearchRecipesDataQuery request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.SearchRecipes(request.queryParameter);
        }
    }

}
