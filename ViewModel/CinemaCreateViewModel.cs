using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.ViewModel
{
    public class CinemaCreateViewModel
    {
        [Required(ErrorMessage = "Cinema name is required.")]
        [StringLength(80, ErrorMessage = "Cinema name is too long.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(50, ErrorMessage = "Locaiton is too long.")]
        public string Location { get; set; } = null!;
    }
}
