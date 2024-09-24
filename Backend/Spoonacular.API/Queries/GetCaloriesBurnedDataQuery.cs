using MediatR;
using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.ApiData;

namespace Spoonacular.API.Queries
{
    public record GetCaloriesBurnedDataQuery() : IRequest<CalBurnedData>;

    public class GetCaloriesBurnedDataQueryHandler : IRequestHandler<GetCaloriesBurnedDataQuery, CalBurnedData>
    {
        IExternalVendorRepository _externalVendorRepository;
        public GetCaloriesBurnedDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository;
        }
        public async Task<CalBurnedData> Handle(GetCaloriesBurnedDataQuery request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.GetCaloriesBurned();
        }
    }

}
