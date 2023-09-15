namespace SupplyService.Contracts.Communication
{
    public interface IEmailService
    {
        Task SendAsync(string emailAddress, string text);
    }
}
