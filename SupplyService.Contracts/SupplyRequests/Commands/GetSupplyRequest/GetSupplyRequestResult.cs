using SupplyService.DomainShared.Enums;

namespace SupplyService.Contracts.SupplyRequests.Commands.GetSupplyRequest
{
    public class GetSupplyRequestResult
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SupplyRequestDepartment SupplyRequestDepartment { get; set; }
    }
}
