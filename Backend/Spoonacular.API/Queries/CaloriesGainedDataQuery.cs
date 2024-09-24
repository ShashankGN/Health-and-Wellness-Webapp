using MediatR;
using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Queries
{
    public record CaloriesGainedDataQuery(CaloriesGainedQueryData queryParameter): IRequest<double>;

    public class CaloriesGainedDataQueryHandler : IRequestHandler<CaloriesGainedDataQuery,double>
    {
        IExternalVendorRepository _externalVendorRepository;
        public CaloriesGainedDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository;
        }
        public async Task<double> Handle(CaloriesGainedDataQuery request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.SearchCaloriesGained(request.queryParameter);
        }
    }

}
