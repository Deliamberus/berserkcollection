using BerserkCollection.Domain.Entities;
using BerserkCollection.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BerserkCollection.Domain.Repositories
{
    public class CollectionRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<UserAccount> _userManager;
        private readonly CardRepository _cardRepository;

        public CollectionRepository(AppDbContext context, UserManager<UserAccount> userManager, CardRepository cardRepository)
        {
            _context = context;
            _userManager = userManager;
            _cardRepository = cardRepository;
        }

        public List<UserCards> GetUserCards(string userId) 
        {
            return _context.UserCards
                .Include(x => x.User)
                .Include(x => x.Card)
                .Where(x => x.User.Id == userId).ToList();
        }

        public void SaveCard(string userid, SaveCardViewModel cardIn)
        {
            var cardsFromDb = GetUserCards(userid);
            var cardFromDb = cardsFromDb.FirstOrDefault(x => x.Card.Id == cardIn.Id);
            if (cardFromDb == null)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
                var card = _cardRepository.GetCardById(cardIn.Id);
                _context.UserCards.Add(new UserCards(user, card, cardIn.Count));
            }
            else
            {
                if(cardIn.Count == 0)
                {
                    _context.UserCards.Remove(cardFromDb);
                }
                cardFromDb.Count = cardIn.Count;
            }
            _context.SaveChanges();
        }
    }
}
