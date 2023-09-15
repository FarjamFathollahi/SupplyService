using SupplyService.Contracts.LogService;
using SupplyService.Domain.Entities;
using SupplyService.Infrastructure.Data;
using System.Text.Json;

namespace SupplyService.Infrastructure.LogService
{
    public class LoggerDatabaseService : ILoggerService
    {
        ApplicationDbContext _context;
        public LoggerDatabaseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task LogAsync(string content, object data, string userId, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(data);
            var log = new Log
            {
                Content = content,
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Data = json
            };
            await _context.Logs.AddAsync(log, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
