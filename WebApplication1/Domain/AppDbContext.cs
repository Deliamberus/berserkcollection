using BerserkCollection.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BerserkCollection.Domain
{
    public partial class AppDbContext : IdentityDbContext<UserAccount>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<UserCards> UserCards { get; set; }
    }
}
