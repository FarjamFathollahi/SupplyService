namespace SupplyService.Contracts.LogService
{
    public interface ILoggerService
    {
        Task LogAsync(string content, object data, string userId, CancellationToken cancellationToken = default);
    }
}
