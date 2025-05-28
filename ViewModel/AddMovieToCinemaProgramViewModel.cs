﻿namespace CinemaWebApp.ViewModel
{
    public class AddMovieToCinemaProgramViewModel
    {
        public int MovieId { get; set; }

        public string MovieTitle { get; set; } = null!;

        public List<CinemaCheckBoxItem> Cinemas { get; set; } = new List<CinemaCheckBoxItem>(); 
    }
}
