using MediatR;
using Spoonacular.API.Contracts;
using Spoonacular.API.DTO.ApiData;
using Spoonacular.API.DTO.QueryParameter;

namespace Spoonacular.API.Queries
{
    public record CaloriesManagementDataQuery(CalBurnedQueryData queryParameter) : IRequest<bool>;

    public class CaloriesManagementDataQueryHandler : IRequestHandler<CaloriesManagementDataQuery, bool>
    {
        IExternalVendorRepository _externalVendorRepository;
        public CaloriesManagementDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository;
        }
        public async Task<bool> Handle(CaloriesManagementDataQuery request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.AddCaloriesBurned(request.queryParameter);
        }
    }
}
