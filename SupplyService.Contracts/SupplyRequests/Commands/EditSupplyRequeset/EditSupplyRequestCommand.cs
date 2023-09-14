using MediatR;
using SupplyService.DomainShared.Enums;

namespace SupplyService.Contracts.SupplyRequests.Commands.EditSupplyRequeset
{
    public class EditSupplyRequestCommand : IRequest<EditSupplyRequestResult>
    {
        public string Id { get; set; }
        public string? UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SupplyRequestDepartment SupplyRequestDepartment { get; set; }
    }
}
