using MediatR;

namespace SupplyService.Contracts.SupplyRequests.Commands.GetSupplyRequest
{
    public class GetSupplyRequestQuery : IRequest<GetSupplyRequestResult>
    {
        public GetSupplyRequestQuery(string id, string userId)
        {
            Id = id;
            UserId = userId;
        }

        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
