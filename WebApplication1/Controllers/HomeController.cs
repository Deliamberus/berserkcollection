using Microsoft.AspNetCore.Mvc;
using BerserkCollection.Models;

namespace BerserkCollection.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(GetCards());
        }

        [HttpPost]
        public IActionResult SaveCard([FromBody] Card card)
        {
            using (BerserkcollectionContext db = new BerserkcollectionContext())
            {
                var dbcard = db.Cards.Where(x => x.Id == card.Id).FirstOrDefault();
                dbcard.Count = card.Count;

                db.SaveChanges();

                return Ok("ok");
            }
        }

        private List<Card> GetCards()
        {
            using (BerserkcollectionContext db = new BerserkcollectionContext())
            {
                var cards = db.Cards.ToList();

                return cards;
            }
        }
    }
}