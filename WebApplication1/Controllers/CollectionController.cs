using BerserkCollection.Domain.Entities;
using BerserkCollection.Domain.Repositories;
using BerserkCollection.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize]
        public IActionResult Collection()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return View("Index", "Home");
            }

            var allCards = _cardRepository.GetAllCards();
            var userCards = _collectionRepository.GetUserCards(userId);

            return View(GetCollectionViewModels(allCards, userCards));
        }

        [HttpPost]
        public IActionResult SaveCard([FromBody] Card card)
        {

            _collectionRepository.SaveCard(card);
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
