using Microsoft.AspNetCore.Mvc;

namespace CinemaWebApp.Controllers
{
    public class CinemaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
