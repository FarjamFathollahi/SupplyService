using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupplyService.Contracts.Users.Repositories;
using SupplyService.Infrastructure.Data;

namespace SupplyService.Infrastructure.Repositories
{
    public class UserReposirtory : IUserRepository
    {
        ApplicationDbContext _context;

        public UserReposirtory(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IdentityUser> GetAsync(string id)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
