using MediatR;
using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Queries
{
    public record ExerciseSuggestionDataQuery(ExerciseSuggestionQueryData queryParameter) : IRequest<List<ExerciseSuggetionData>>;

    public class ExerciseSuggestionDataQueryHandler : IRequestHandler<ExerciseSuggestionDataQuery, List<ExerciseSuggetionData>>
    {
        IExternalVendorRepository _externalVendorRepository;
        public ExerciseSuggestionDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository;
        }
        public async Task<List<ExerciseSuggetionData>> Handle(ExerciseSuggestionDataQuery request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.SearchExerciseSuggestion(request.queryParameter);
        }
    }
}
