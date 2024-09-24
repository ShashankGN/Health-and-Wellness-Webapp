using MediatR;
using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.ApiData;

namespace Spoonacular.API.Queries
{
    public record GetCaloriesGainedDataQuery() : IRequest<CalGainedData>;

    public class GetCaloriesGainedDataQueryHandler : IRequestHandler<GetCaloriesGainedDataQuery, CalGainedData>
    {
        IExternalVendorRepository _externalVendorRepository;
        public GetCaloriesGainedDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository;
        }
        public async Task<CalGainedData> Handle(GetCaloriesGainedDataQuery request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.GetCaloriesGained();
        }
    }
}
