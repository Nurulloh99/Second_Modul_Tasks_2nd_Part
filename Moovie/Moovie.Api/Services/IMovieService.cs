using Moovie.Api.Services.DTOs;

namespace Moovie.Api.Services;

public interface IMovieService
{
    MovieGetDto AddMovie(MovieCreateDto movie);
    MovieGetDto GetMovieById(Guid movieId);
    List<MovieGetDto> GetAllMovies();
    void DeleteMovie(Guid movieId);
    void UpdateMovie(MovieUpdateDto movie);
    List<MovieGetDto> GetAllMoviesByDirector(string director);
    MovieGetDto GetTopRatedMovie();
    List<MovieGetDto> GetMoviesReleasedAfterYear(int year);
    MovieGetDto GetHighestGrossingMovie();
    List<MovieGetDto> SearchMoviesByTitle(string keyword);
    List<MovieGetDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes);
    long GetTotalBoxOfficeEarningsByDirector(string director);
    List<MovieGetDto> GetMoviesSortedByRating();
    List<MovieGetDto> GetRecentMovies(int years);
}
