using Microsoft.AspNetCore.Mvc;

namespace BerserkCollection.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}