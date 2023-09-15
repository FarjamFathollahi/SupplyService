using MediatR;
using SupplyService.Contracts.Communication;
using SupplyService.Contracts.LogService;
using SupplyService.Contracts.SupplyRequests.Commands.CreateSupplyRequest;
using SupplyService.Contracts.SupplyRequests.Repositories;
using SupplyService.Contracts.Users.Repositories;

namespace SupplyService.Application.SupplyRequests
{
    public class CreateSupplyRequestCommandHandler : IRequestHandler<CreateSupplyRequestCommand, CreateSupplyRequestResult>
    {
        ISupplyRequestRepository _supplyRequestRepository;
        IUserRepository _userRepository;
        ISmsService _smsService;
        IEmailService _emailService;
        ILoggerService _loggerService;
        public CreateSupplyRequestCommandHandler(ISupplyRequestRepository supplyRequestRepository, ISmsService smsService, IEmailService emailService, ILoggerService loggerService, IUserRepository userRepository)
        {
            _supplyRequestRepository = supplyRequestRepository;
            _smsService = smsService;
            _emailService = emailService;
            _loggerService = loggerService;
            _userRepository = userRepository;
        }
        public async Task<CreateSupplyRequestResult> Handle(CreateSupplyRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            var supplyRequest = new Domain.Entities.SupplyRequest(request.Title, request.Description, request.UserId, request.Department);
            supplyRequest.User = user;
            await _supplyRequestRepository.AddSupplyRequestAsync(supplyRequest, cancellationToken);
            await _supplyRequestRepository.SaveChangesAsync(cancellationToken);
            _loggerService.LogAsync("Supply Request Created", supplyRequest, request.UserId);
            _smsService.SendAsync(supplyRequest.User.PhoneNumber, "Supply Request Created");
            _emailService.SendAsync(supplyRequest.User.Email, "Supply Request Created");
            return new CreateSupplyRequestResult(supplyRequest.Id);
        }
    }
}
