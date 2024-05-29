namespace CinemaCity.Services
{
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Cinema;

    public class CinemaService : ICinemaService
    {
        private readonly CinemaCityContext _context;

        public CinemaService(CinemaCityContext context)
        {
            _context = context;
        }

        public async Task<List<CinemaViewModel>> GetCinemas()
        {
            var cinemas = await _context.Cinemas
                .Select(c => new CinemaViewModel
                {
                    Id = c.Id,
                    Name = c.CinemaName,
                    Location = c.Location
                })
                .ToListAsync();

            return cinemas;
        }
    }
}
