using MediatR;
using SupplyService.Contracts.SupplyRequests.Commands.EditSupplyRequeset;
using SupplyService.Contracts.SupplyRequests.Repositories;

namespace SupplyService.Application.SupplyRequests
{
    public class EditSupplyRequestCommandHandler : IRequestHandler<EditSupplyRequestCommand, EditSupplyRequestResult>
    {
        ISupplyRequestRepository _supplyRequestRepository;
        public EditSupplyRequestCommandHandler(ISupplyRequestRepository supplyRequestRepository)
        {
            _supplyRequestRepository = supplyRequestRepository;
        }
        public async Task<EditSupplyRequestResult> Handle(EditSupplyRequestCommand request, CancellationToken cancellationToken)
        {
            var item =await _supplyRequestRepository.GetSupplyRequestAsync(request.Id, request.UserId, cancellationToken);
            item.EditSupplyRequest(request.Title, request.Description, request.SupplyRequestDepartment);
            _supplyRequestRepository.UpdateSupplyRequest(item);
            await _supplyRequestRepository.SaveChangesAsync(cancellationToken);
            return new EditSupplyRequestResult();
        }
    }
}
