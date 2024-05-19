namespace CinemaCity.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Configurations;
    using Models;

    public class CinemaCityContext : IdentityDbContext<ApplicationUser>
    {
        public CinemaCityContext(DbContextOptions<CinemaCityContext> options)
            : base(options)
        {
        }

        public CinemaCityContext()
        {
        }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Screen> Screens { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Showtime> Showtimes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CinemaConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new ScreenConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());

            builder.Entity<Screen>()
                .HasOne(s => s.Cinema)
                .WithMany(c => c.Screens)
                .HasForeignKey(s => s.CinemaId);

            builder.Entity<Showtime>()
                .HasOne(st => st.Movie)
                .WithMany(m => m.Showtimes)
                .HasForeignKey(st => st.MovieId);

            builder.Entity<Showtime>()
                .HasOne(st => st.Screen)
                .WithMany(s => s.Showtimes)
                .HasForeignKey(st => st.ScreenId);

            builder.Entity<Seat>()
                .HasOne(se => se.Screen)
                .WithMany(s => s.Seats)
                .HasForeignKey(se => se.ScreenId);

            builder.Entity<Booking>()
                .HasOne(b => b.Showtime)
                .WithMany(st => st.Bookings)
                .HasForeignKey(b => b.ShowtimeId);

            builder.Entity<Seat>()
                .HasMany(s => s.Bookings)
                .WithMany(b => b.Seats)
                .UsingEntity<Dictionary<string, object>>(
                    "BookingSeat",
                    bs => bs.HasOne<Booking>()
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Restrict),
                    bs => bs.HasOne<Seat>()
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Restrict));

            builder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            base.OnModelCreating(builder);
        }
    }
}
