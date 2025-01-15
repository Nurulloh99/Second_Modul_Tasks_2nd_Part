using Movie.DataAccess.Entities;
using Movie.Service.DTOs;

namespace Movie.Service.Service;

public interface IMovieService
{
    MovieDto AddMovie(MovieDto movie);
    MovieDto GetMovieById(Guid id);
    List<MovieDto> GetAllMovies();
    void DeleteMovie(Guid movieId);
    void UpdateMovie(MovieDto movie);
    List<MovieDto> GetAllMoviesByDirector(string director);
    MovieDto GetTopRatedMovie(); // ratingi eng baland film qaytarilsin
    List<MovieDto> GetMoviesReleasedAfterYear(int year); // yilidan keyin chiqqan filmlar qaytarilsin
    MovieDto GetHighestGrossingMovie(); // eng ko'p daromad qilgan film qaytarilsin
    List<MovieDto> SearchMoviesByTitle(string keyword); // titleda keyword qatnashgan filmlar royxati qaytsin
    List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes); // davomiyligi min va max oralig'ida bo'lgan filmlar
    long GetTotalBoxOfficeEarningsByDirector(string director); // directorning filmlari qancha daromad qilgani qaytarilsin
    List<MovieDto> GetMoviesSortedByRating(); // baholanish bo'yicha sortlab bering. Kattadan kichikga
    List<MovieDto> GetRecentMovies(int years); // so'nggi yil ichida chiqqan filmlar royxati qaytarilsin.
}
