using MediatR;
using SupplyService.Contracts.SupplyRequests.Commands.GetAllSupplyRequests;
using SupplyService.Contracts.SupplyRequests.Repositories;

namespace SupplyService.Application.SupplyRequests
{
    public class GetAllSupplyRequestQueryHandler : IRequestHandler<GetAllSupplyRequestsQuery, List<GetAllSupplyRequestsResult>>
    {
        ISupplyRequestRepository _supplyRequestRepository;
        public GetAllSupplyRequestQueryHandler(ISupplyRequestRepository supplyRequestRepository)
        {
            _supplyRequestRepository = supplyRequestRepository;
        }
        public async Task<List<GetAllSupplyRequestsResult>> Handle(GetAllSupplyRequestsQuery request, CancellationToken cancellationToken)
        {
            var list = await _supplyRequestRepository.GetAllSupplyRequestsAsync(request.UserId, cancellationToken);
            return list.Select(s => new GetAllSupplyRequestsResult
            {
                Id = s.Id,
                SupplyRequestDepartment = s.Department,
                Title = s.Title
            }).ToList();
        }
    }
}
