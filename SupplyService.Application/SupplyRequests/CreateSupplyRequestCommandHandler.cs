using MediatR;
using SupplyService.Contracts.SupplyRequests.Commands.CreateSupplyRequest;
using SupplyService.Contracts.SupplyRequests.Repositories;

namespace SupplyService.Application.SupplyRequests
{
    public class CreateSupplyRequestCommandHandler : IRequestHandler<CreateSupplyRequestCommand, CreateSupplyRequestResult>
    {
        ISupplyRequestRepository _supplyRequestRepository;
        public CreateSupplyRequestCommandHandler(ISupplyRequestRepository supplyRequestRepository)
        {
            _supplyRequestRepository = supplyRequestRepository;
        }
        public async Task<CreateSupplyRequestResult> Handle(CreateSupplyRequestCommand request, CancellationToken cancellationToken)
        {
            var supplyRequest = new Domain.Entities.SupplyRequest(request.Title, request.Description, request.UserId, request.Department);
            await _supplyRequestRepository.AddSupplyRequestAsync(supplyRequest, cancellationToken);
            await _supplyRequestRepository.SaveChangesAsync(cancellationToken);
            return new CreateSupplyRequestResult(supplyRequest.Id);
        }
    }
}
