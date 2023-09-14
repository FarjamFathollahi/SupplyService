using MediatR;
using SupplyService.Contracts.SupplyRequests.Commands.DeleteSupplyRequest;
using SupplyService.Contracts.SupplyRequests.Repositories;

namespace SupplyService.Application.SupplyRequests
{
    public class DeleteSupplyRequestCommandHandler : IRequestHandler<DeleteSupplyRequestCommand, DeleteSupplyRequestResult>
    {
        ISupplyRequestRepository _supplyRequestRepository;
        public DeleteSupplyRequestCommandHandler(ISupplyRequestRepository supplyRequestRepository)
        {
            _supplyRequestRepository = supplyRequestRepository;
        }

        public async Task<DeleteSupplyRequestResult> Handle(DeleteSupplyRequestCommand request, CancellationToken cancellationToken)
        {
            var item = await _supplyRequestRepository.GetSupplyRequestAsync(request.Id, request.UserId, cancellationToken);
            item.Delete();
            _supplyRequestRepository.UpdateSupplyRequest(item);
            await _supplyRequestRepository.SaveChangesAsync(cancellationToken);
            return new DeleteSupplyRequestResult();
        }
    }
}
