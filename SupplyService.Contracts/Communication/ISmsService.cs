namespace SupplyService.Contracts.Communication
{
    public interface ISmsService
    {
        Task SendAsync(string phoneNumber, string text);
    }
}
