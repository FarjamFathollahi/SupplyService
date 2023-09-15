using MediatR;
using SupplyService.Contracts.LogService;
using SupplyService.Contracts.SupplyRequests.Commands.DeleteSupplyRequest;
using SupplyService.Contracts.SupplyRequests.Repositories;

namespace SupplyService.Application.SupplyRequests
{
    public class DeleteSupplyRequestCommandHandler : IRequestHandler<DeleteSupplyRequestCommand, DeleteSupplyRequestResult>
    {
        ISupplyRequestRepository _supplyRequestRepository;
        ILoggerService _loggerService;

        public DeleteSupplyRequestCommandHandler(ISupplyRequestRepository supplyRequestRepository, ILoggerService loggerService)
        {
            _supplyRequestRepository = supplyRequestRepository;
            _loggerService = loggerService;
        }

        public async Task<DeleteSupplyRequestResult> Handle(DeleteSupplyRequestCommand request, CancellationToken cancellationToken)
        {
            var item = await _supplyRequestRepository.GetSupplyRequestAsync(request.Id, request.UserId, cancellationToken);
            item.Delete();
            _supplyRequestRepository.UpdateSupplyRequest(item);
            await _supplyRequestRepository.SaveChangesAsync(cancellationToken);
            _loggerService.LogAsync("Supply Request Deleted", item, request.UserId);
            return new DeleteSupplyRequestResult();
        }
    }
}
