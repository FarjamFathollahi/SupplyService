﻿using MediatR;
using SupplyService.Contracts.LogService;
using SupplyService.Contracts.SupplyRequests.Commands.EditSupplyRequeset;
using SupplyService.Contracts.SupplyRequests.Repositories;

namespace SupplyService.Application.SupplyRequests
{
    public class EditSupplyRequestCommandHandler : IRequestHandler<EditSupplyRequestCommand, EditSupplyRequestResult>
    {
        ISupplyRequestRepository _supplyRequestRepository;
        ILoggerService _loggerService;

        public EditSupplyRequestCommandHandler(ISupplyRequestRepository supplyRequestRepository, ILoggerService loggerService)
        {
            _supplyRequestRepository = supplyRequestRepository;
            _loggerService = loggerService;
        }
        public async Task<EditSupplyRequestResult> Handle(EditSupplyRequestCommand request, CancellationToken cancellationToken)
        {
            var item = await _supplyRequestRepository.GetSupplyRequestAsync(request.Id, request.UserId, cancellationToken);
            item.EditSupplyRequest(request.Title, request.Description, request.SupplyRequestDepartment);
            _supplyRequestRepository.UpdateSupplyRequest(item);
            await _supplyRequestRepository.SaveChangesAsync(cancellationToken);
            _loggerService.LogAsync("Supply Request Edited", item, request.UserId); 
            return new EditSupplyRequestResult();
        }
    }
}
