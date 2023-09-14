using MediatR;
using SupplyService.DomainShared.Enums;

namespace SupplyService.Contracts.SupplyRequests.Commands.CreateSupplyRequest
{
    public class CreateSupplyRequestCommand : IRequest<CreateSupplyRequestResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? UserId { get; set; }
        public SupplyRequestDepartment Department { get; set; }
    }
}
