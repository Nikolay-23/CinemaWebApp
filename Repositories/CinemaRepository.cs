using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using CinemaWebApp.Repositories.Contracts;

namespace CinemaWebApp.Repositories
{
    public class CinemaRepository : Repository<Cinema> , ICinemaRepository
    {
        public CinemaRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
