using Movie.DataAccess.Entities;

namespace Movie.Repository.Service
{
    public interface IRepositoryService
    {
        Guid WriteMovie(Film movie);
        Film ReadMovieById(Guid id);
        List<Film> ReadAllMovies();
        void RemoveMovie(Guid movieId);
        void UpdateMovie(Film movie);
    }
}