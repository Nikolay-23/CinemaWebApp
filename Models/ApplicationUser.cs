using Microsoft.AspNetCore.Identity;

namespace CinemaWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
