using SupplyService.Domain.Entities;

namespace SupplyService.Contracts.SupplyRequests.Repositories
{
    public interface ISupplyRequestRepository
    {
        Task<SupplyRequest> GetSupplyRequestAsync(string id , string userId , CancellationToken cancellationToken = default);
        Task<List<SupplyRequest>> GetAllSupplyRequestsAsync(string userId , CancellationToken cancellationToken = default);
        Task AddSupplyRequestAsync(SupplyRequest supplyRequest, CancellationToken cancellationToken = default);
        void UpdateSupplyRequest(SupplyRequest supplyRequest);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
