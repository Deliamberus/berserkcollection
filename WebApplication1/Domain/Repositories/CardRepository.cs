using BerserkCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public Card? GetCardById(int id)
        {
            var card = _context.Cards.FirstOrDefault(x => x.Id == id);
            return card;
        }
    }
}
