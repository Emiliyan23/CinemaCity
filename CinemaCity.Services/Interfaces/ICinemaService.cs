namespace CinemaCity.Services.Interfaces
{
    using Web.ViewModels.Cinema;

    public interface ICinemaService
    {
        Task<List<CinemaViewModel>> GetCinemas();
    }
}
