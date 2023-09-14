using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupplyService.Domain.Entities;

namespace SupplyService.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<SupplyRequest> SupplyRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SupplyRequest>()
                    .HasQueryFilter(supplyRequest => supplyRequest.IsDeleted == false);

            base.OnModelCreating(builder);
        }
    }
}
