using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using CinemaWebApp.Repositories.Contracts;

namespace CinemaWebApp.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context) 
        {
            
        }
    }
}
