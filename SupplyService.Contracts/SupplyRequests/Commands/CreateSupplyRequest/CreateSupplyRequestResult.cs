namespace SupplyService.Contracts.SupplyRequests.Commands.CreateSupplyRequest
{
    public class CreateSupplyRequestResult
    {
        public string Id { get; set; }

        public CreateSupplyRequestResult(string id)
        {
            Id = id;
        }
    }
}
