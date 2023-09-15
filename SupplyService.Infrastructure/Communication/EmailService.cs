using SupplyService.Contracts.Communication;

namespace SupplyService.Infrastructure.Communication
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(string emailAddress, string text)
        {
        }
    }
}
