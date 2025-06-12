using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using CinemaWebApp.Repositories.Contracts;
using CinemaWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Controllers
{
    public class CinemaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICinemaRepository _cinemaService;
        public CinemaController(AppDbContext context, ICinemaRepository cinemaService)
        {
            _context = context;
            _cinemaService = cinemaService;
        }

        public IActionResult Index()
        {
            //Fetch the list of cinemas from the database
            var cinemas = _context.Cinemas.ToList();

            //Map the Cinema entities to CinemaIndexViewModel
            var cinemaIndexViewModels = cinemas.Select(c => new CinemaIndexViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Location = c.Location
            });

            //Pass the list of CinemaIndexViewModels to the view
            return View(cinemaIndexViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Create(CinemaIndexViewModel cinemaIndexViewModel)
        {
            if(ModelState.IsValid)
            {
                var cinema = new Cinema
                {
                    Name = cinemaIndexViewModel.Name,
                    Location = cinemaIndexViewModel.Location
                };

                _context.Cinemas.Add(cinema);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(cinemaIndexViewModel);
        }

        public IActionResult Details(int id)
        {
            //Fetch cinema by its id, including its related movies
            var cinema = _context.Cinemas
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .FirstOrDefault(c => c.Id == id);

            if (cinema == null)
            {
                return RedirectToAction("Index");
            }

            //Map the Cinema object to a CinemaDetailsViewModel object
            var cinemaDetailsViewModel = new CinemaDetailsViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Location = cinema.Location,
                Movies = cinema.CinemaMovies.Select(cm => new MovieProgramViewModel
                {
                    Title = cm.Movie.Title,
                    Duration = cm.Movie.Duration
                }).ToList()
            };

            //Pass the CinemaDetailsViewModel object to the view
            return View(cinemaDetailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = await
              _cinemaService.IndexGetAllOrderedByLocationAsunc();
            return this.View(cinemas);
        }
    }
}
