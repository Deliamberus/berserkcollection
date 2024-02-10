using Microsoft.AspNetCore.Mvc;

namespace BerserkCollection.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Collection", "Collection");
            }
            return View();
        }
    }
}