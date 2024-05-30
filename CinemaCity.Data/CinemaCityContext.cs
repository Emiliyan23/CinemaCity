namespace CinemaCity.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Configurations;
    using Microsoft.AspNetCore.Identity;
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
            var adminUser = new ApplicationUser
            {
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin123");

            builder.Entity<ApplicationUser>().HasData(adminUser);


            builder.ApplyConfiguration(new CinemaConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new ShowtimeConfiguration());
            builder.ApplyConfiguration(new TicketTypeConfiguration());
            builder.ApplyConfiguration(new SeatConfiguration());

            builder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    BookingDate = new DateTime(2024, 5, 30, 10, 36, 00),
                    ShowtimeId = 1,
                    UserId = adminUser.Id
                },
                new Booking
                {
                    Id = 2,
                    BookingDate = new DateTime(2024, 5, 29, 11, 40, 0),
                    ShowtimeId = 7,
                    UserId = adminUser.Id
                }
			);

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
