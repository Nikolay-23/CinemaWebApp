using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Models.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //DbSet<Movie> Movies will be used to interact with the Movies table
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaMovie> CinemasMovies { get; set; }
        public DbSet<UserMovie> UsersMovies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure the composite key for the CinemaMovie entity
            modelBuilder.Entity<CinemaMovie>()
                .HasKey(cm => new { cm.CinemaId, cm.MovieId });

            //Configure the relationship between Cinema and CinemaMovie
            modelBuilder.Entity<CinemaMovie>()     
                .HasOne(cm => cm.Cinema)            //A CinemaMovie entity has one Cinema...
                .WithMany(c => c.CinemaMovies)      //A Cinema entity can have many CinemaMovies
                .HasForeignKey(cm => cm.CinemaId);  //CinemaId is the foreign key in CinemaMovie

            //Configure the relationship between Movie and CinemaMovie
            modelBuilder.Entity<CinemaMovie>()
                 .HasOne(cm => cm.Movie)            //A CinemaMovie entity has one Movie...
                 .WithMany(m => m.CinemaMovies)     //A Movie entity can have many CinemaMovies
                 .HasForeignKey(cm => cm.MovieId);  //MovieId is the foreign key in CinemaMovie

            //Define the composite key for the UserMovie entity
            modelBuilder.Entity<UserMovie>()
                .HasKey(um => new { um.UserId, um.MovieId });

            //Configure the relationship berween the UserMovie and IdentityUser entities
            modelBuilder.Entity<UserMovie>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(um => um.UserId);

            //Configure the relationship between the UserMovie and Movie entities
            modelBuilder.Entity<UserMovie>()
                .HasOne(um => um.Movie)
                .WithMany()
                .HasForeignKey(um => um.MovieId);

            //Ticket: Cinema relationship
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Cinema)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);  //Cascades delete when cinema is deleted

            //Ticket: Movie reltionship
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Movie)
                .WithMany(m => m.Tickets)
                .HasForeignKey(t => t.MovieId)
                .OnDelete(DeleteBehavior.Cascade); //Cascades delete when movie is deleted

            //Ticket: User raltionship
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany() //No navigation property on IdentityUser
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict); //Resctrict deletion of a user if they have tickets

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18,2");
        }

        
    }
}
