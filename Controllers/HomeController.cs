using System.Diagnostics;
using CinemaWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Message = "Welcome to the Cinema Web App!";

            return View();
        }
    }
}
