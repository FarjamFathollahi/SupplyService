using Microsoft.EntityFrameworkCore;
using SupplyService.Contracts.SupplyRequests.Repositories;
using SupplyService.Domain.Entities;
using SupplyService.Infrastructure.Data;

namespace SupplyService.Infrastructure.Repositories
{
    public class SupplyRequestRepository : ISupplyRequestRepository
    {
        ApplicationDbContext _context;
        public SupplyRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddSupplyRequestAsync(SupplyRequest supplyRequest, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(supplyRequest, cancellationToken);
        }

        public async Task<List<SupplyRequest>> GetAllSupplyRequestsAsync(string userId, CancellationToken cancellationToken = default)
        {
            return await _context.SupplyRequests.Where(s => s.UserId == userId).ToListAsync();
        }

        public async Task<SupplyRequest> GetSupplyRequestAsync(string id, string userId, CancellationToken cancellationToken = default)
        {
            return await _context.SupplyRequests.Where(s => s.UserId == userId && s.Id == id).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void UpdateSupplyRequest(SupplyRequest supplyRequest)
        {
            _context.Entry(supplyRequest).State = EntityState.Modified;
        }
    }
}
