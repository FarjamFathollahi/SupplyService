using MediatR;
using SupplyService.Contracts.SupplyRequests.Commands.GetSupplyRequest;
using SupplyService.Contracts.SupplyRequests.Repositories;

namespace SupplyService.Application.SupplyRequests
{
    public class GetSupplyRequestQueryHandler : IRequestHandler<GetSupplyRequestQuery, GetSupplyRequestResult>
    {
        ISupplyRequestRepository _supplyRequestRepository;
        public GetSupplyRequestQueryHandler(ISupplyRequestRepository supplyRequestRepository)
        {
            _supplyRequestRepository = supplyRequestRepository;
        }
        public async Task<GetSupplyRequestResult> Handle(GetSupplyRequestQuery request, CancellationToken cancellationToken)
        {
            var item = await _supplyRequestRepository.GetSupplyRequestAsync(request.Id, request.UserId, cancellationToken);
            return new GetSupplyRequestResult
            {
                Id = item.Id,
                Description = item.Description,
                SupplyRequestDepartment = item.Department,
                Title = item.Title
            };
        }
    }
}
