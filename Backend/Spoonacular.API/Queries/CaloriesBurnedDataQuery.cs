using MediatR;
using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Queries
{
    public record CaloriesBurnedDataQuery(CaloriesBurnedQueryData queryParameter) : IRequest<List<CaloriesBurnedData>>;

    public class CaloriesBurnedDataQueryHandler : IRequestHandler<CaloriesBurnedDataQuery, List<CaloriesBurnedData>>
    {
        IExternalVendorRepository _externalVendorRepository;
        public CaloriesBurnedDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository;
        }
        public async Task<List<CaloriesBurnedData>> Handle(CaloriesBurnedDataQuery request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.SearchCaloriesBurned(request.queryParameter);
        }
    }
}
