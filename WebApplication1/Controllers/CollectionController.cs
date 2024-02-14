using BerserkCollection.Domain.Entities;
using BerserkCollection.Domain.Repositories;
using BerserkCollection.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace BerserkCollection.Controllers
{
    public class CollectionController : Controller
    {
        private readonly CardRepository _cardRepository;
        private readonly CollectionRepository _collectionRepository;

        public CollectionController(CardRepository cardRepository, CollectionRepository collectionRepository)
        {
            _cardRepository = cardRepository;
            _collectionRepository = collectionRepository;
        }

        public IActionResult Collection()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var allCards = _cardRepository.GetAllCards();
            var userCards = _collectionRepository.GetUserCards(userId);

            return View(GetCollectionViewModels(allCards, userCards));
        }

        [HttpPost]
        [Authorize]
        public IActionResult SaveCard([FromBody] SaveCardViewModel card)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            _collectionRepository.SaveCard(userId, card);
            return Ok("ok");
        }

        public List<CollectionViewModel> GetCollectionViewModels(List<Card> cards, List<UserCards> userCards)
        {
            List<CollectionViewModel> collection = new List<CollectionViewModel>();

            foreach (Card card in cards)
            {
                CollectionViewModel collectionItem = new CollectionViewModel(card);
                var userCard = userCards.FirstOrDefault(x => x.Card.Id == card.Id);
                if (userCard != null)
                {
                    collectionItem.Count = userCard.Count;
                }
                collection.Add(collectionItem);
            }

            return collection;
        }
    }
}
