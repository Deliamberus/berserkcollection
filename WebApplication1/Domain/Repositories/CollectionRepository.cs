using BerserkCollection.Domain.Entities;

namespace BerserkCollection.Domain.Repositories
{
    public class CollectionRepository
    {
        private readonly AppDbContext _context;

        public CollectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<UserCards> GetUserCards(string userId) 
        {
            return _context.UserCards.Where(x => x.User.Id == userId).ToList();
        }

        public void SaveCard(Card card)
        {
            var dbcard = _context.Cards.Where(x => x.Id == card.Id).FirstOrDefault();
            //dbcard.Count = card.Count;

            _context.SaveChanges();
        }
    }
}
