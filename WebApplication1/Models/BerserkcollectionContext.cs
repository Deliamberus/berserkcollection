using Microsoft.EntityFrameworkCore;

namespace BerserkCollection.Models
{
    public partial class BerserkcollectionContext : DbContext
    {
        public BerserkcollectionContext()
        {
        }

        public BerserkcollectionContext(DbContextOptions<BerserkcollectionContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Berserkcollection;TrustServerCertificate=true;User=bers;Password=bers123456");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<Card> Cards { get; set; }
    }
}
