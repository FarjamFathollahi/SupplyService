using Microsoft.AspNetCore.Identity;

namespace SupplyService.Contracts.Users.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityUser> GetAsync(string id);
    }
}
