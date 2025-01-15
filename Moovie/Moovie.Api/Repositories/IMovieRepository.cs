using Moovie.Api.DataAccess.Entities;

namespace Moovie.Api.Repositories;

public interface IMovieRepository
{
    Guid WriteMovie(Film movie);
    Film ReadMovieById(Guid movieId);
    List<Film> ReadAllMovie();
    void RemoveMovie(Guid movieId);
    void UpdateMovie(Film movie);
}
