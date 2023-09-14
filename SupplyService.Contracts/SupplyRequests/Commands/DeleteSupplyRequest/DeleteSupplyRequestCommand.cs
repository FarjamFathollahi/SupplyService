using MediatR;

namespace SupplyService.Contracts.SupplyRequests.Commands.DeleteSupplyRequest
{
    public class DeleteSupplyRequestCommand : IRequest<DeleteSupplyRequestResult>
    {
        public DeleteSupplyRequestCommand(string id, string userId)
        {
            Id = id;
            UserId = userId;
        }

        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
