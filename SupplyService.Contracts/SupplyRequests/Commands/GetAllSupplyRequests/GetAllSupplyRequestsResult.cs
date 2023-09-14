using SupplyService.DomainShared.Enums;

namespace SupplyService.Contracts.SupplyRequests.Commands.GetAllSupplyRequests
{
    public class GetAllSupplyRequestsResult
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public SupplyRequestDepartment SupplyRequestDepartment { get; set; }
    }
}
