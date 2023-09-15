using SupplyService.Contracts.Communication;

namespace SupplyService.Infrastructure.Communication
{
    public class SmsService : ISmsService
    {
        public async Task SendAsync(string phoneNumber, string text)
        {
        }
    }
}
