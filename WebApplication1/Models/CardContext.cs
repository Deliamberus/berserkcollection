using System.Data.Entity;

namespace BerserkCollection.Models
{
    public class CardContext : DbContext
    {
        public CardContext() : base("Berserkcollection")
        {
        }
        public DbSet<Card> Cards { get; set; }
    }
}
