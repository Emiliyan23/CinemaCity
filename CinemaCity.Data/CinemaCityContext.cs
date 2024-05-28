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

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Showtime> Showtimes { get; set; }

        public DbSet<BookingSeat> BookingSeats { get; set; }

        public DbSet<BookingTicket> BookingTickets { get; set; }

        public DbSet<TicketType> TicketTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CinemaConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new ShowtimeConfiguration());
            builder.ApplyConfiguration(new TicketTypeConfiguration());
            builder.ApplyConfiguration(new SeatConfiguration());
            builder.ApplyConfiguration(new BookingConfiguration());
            builder.ApplyConfiguration(new BookingSeatsConfiguration());
            builder.ApplyConfiguration(new BookingTicketConfiguration());

            builder.Entity<Showtime>()
                .HasOne(st => st.Movie)
                .WithMany(m => m.Showtimes)
                .HasForeignKey(st => st.MovieId);

            builder.Entity<Showtime>()
                .HasOne(st => st.Cinema)
                .WithMany(c => c.Showtimes)
                .HasForeignKey(st => st.CinemaId);

            builder.Entity<Seat>()
                .HasOne(se => se.Cinema)
                .WithMany(s => s.Seats)
                .HasForeignKey(se => se.CinemaId);

            builder.Entity<Booking>()
                .HasOne(b => b.Showtime)
                .WithMany(st => st.Bookings)
                .HasForeignKey(b => b.ShowtimeId);

            builder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            builder.Entity<BookingSeat>()
	            .HasKey(bs => new { bs.BookingId, bs.SeatId });

            builder.Entity<BookingSeat>()
	            .HasOne(bs => bs.Seat)
	            .WithMany(s => s.BookingSeats)
	            .HasForeignKey(bs => bs.SeatId)
	            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BookingSeat>()
	            .HasOne(bs => bs.Booking)
	            .WithMany(b => b.BookingSeats)
	            .HasForeignKey(bs => bs.BookingId)
	            .OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(builder);
        }
    }
}
