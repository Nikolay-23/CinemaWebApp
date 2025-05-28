namespace CinemaWebApp.ViewModel
{
    public class CinemaDetailsViewModel
    {
        public int Id {  get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public ICollection<MovieProgramViewModel> Movies { get; set; } = new List<MovieProgramViewModel>();
    }
}
