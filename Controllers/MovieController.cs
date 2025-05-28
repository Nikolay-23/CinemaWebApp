using Microsoft.AspNetCore.Mvc;
using CinemaWebApp.Models; 
using System.Collections.Generic;
using CinemaWebApp.Models.Data;
using CinemaWebApp.ViewModel;
namespace CinemaWebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;

        //Inject the AppDbContext using constructor dependency injection
        public MovieController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList(); // Retrieve all movies from the database
            return View(movies);
        }

        // GET: Action to display form for creating a new movie
        [HttpGet]
        public IActionResult Create()
        {
            return View(new MovieViewModel());
        }

        // POST: Action to handle form submission for creating a new movie
        [HttpPost]
        public IActionResult Create(MovieViewModel viewModel)
        {
            //Validate the input data using ModelState
            if (ModelState.IsValid)
            {
                //Map the view model to the Movie entity
                var movie = new Movie
                {
                    Title = viewModel.Title,
                    Genre = viewModel.Genre,
                    ReleaseDate = viewModel.ReleaseDate,
                    Director = viewModel.Director,
                    Duration = viewModel.Duration,
                    Description = viewModel.Description
                };

                _context.Movies.Add(movie);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // Action to show details of a specific movie
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Find(id); // Find the movie by id

            if(movie == null)
            {
                return NotFound(); // Return 404 Not Found
            }

            return View(movie);
        }
    }
}
