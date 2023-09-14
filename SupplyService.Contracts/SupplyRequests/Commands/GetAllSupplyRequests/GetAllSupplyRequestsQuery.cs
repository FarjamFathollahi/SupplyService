using MediatR;

namespace SupplyService.Contracts.SupplyRequests.Commands.GetAllSupplyRequests
{
    public class GetAllSupplyRequestsQuery : IRequest<List<GetAllSupplyRequestsResult>>
    {
        public string UserId { get; set; }

        public GetAllSupplyRequestsQuery(string userId)
        {
            UserId = userId;
        }
    }
}
