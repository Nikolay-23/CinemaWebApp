using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using CinemaWebApp.Repositories.Contracts;

namespace CinemaWebApp.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDbContext context): base(context) 
        {
            
        }
    }
}
