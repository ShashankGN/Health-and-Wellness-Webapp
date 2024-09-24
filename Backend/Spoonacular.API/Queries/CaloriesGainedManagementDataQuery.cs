using MediatR;
using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Queries
{
    public record CaloriesGainedManagementDataQuery(CalGaiedQueryData queryParameter):IRequest<bool>;

    public class CaloriesGainedManagementDataQueryHandler : IRequestHandler<CaloriesGainedManagementDataQuery, bool>
    {
        IExternalVendorRepository _externalVendorRepository;
        public CaloriesGainedManagementDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository;
        }
        public async Task<bool> Handle(CaloriesGainedManagementDataQuery request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.AddCaloriesGained(request.queryParameter);
        }
    }
}
