using BerserkCollection.Domain.Entities;

namespace BerserkCollection.Domain.Repositories
{
    public class CardRepository
    {
        private readonly AppDbContext _context;

        public CardRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Card> GetAllCards()
        {
            var cards = _context.Cards.ToList();
            return cards;
        }
    }
}
