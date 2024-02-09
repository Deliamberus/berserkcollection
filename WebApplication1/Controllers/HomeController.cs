using Microsoft.AspNetCore.Mvc;
using BerserkCollection.Domain.Entities;
using BerserkCollection.Domain;
using BerserkCollection.Domain.Repositories;

namespace BerserkCollection.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}