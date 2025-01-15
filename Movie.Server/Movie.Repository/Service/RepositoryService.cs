using System.Text.Json;
using Movie.DataAccess.Entities;

namespace Movie.Repository.Service;

public class RepositoryService : IRepositoryService
{
    private string _path;
    private List<Film> _movies;

    public RepositoryService()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Movies.json");

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _movies = ReadAllMovies();
    }

    public void SaveData()
    {
        var movieJson = JsonSerializer.Serialize(_movies);
        File.WriteAllText(_path, movieJson);
    }

    public List<Film> ReadAllMovies()
    {
        var movieResult = File.ReadAllText(_path);
        var movieJson = JsonSerializer.Deserialize<List<Film>>(movieResult);
        return movieJson;
    }

    public Film ReadMovieById(Guid movieId)
    {
        var movieById = _movies.FirstOrDefault(mv => mv.Id == movieId);
        if(movieById == null)
        {
            throw new Exception("not find");
        }
        
        return movieById;
    }

    public void RemoveMovie(Guid movieId)
    {
        var findMovie = ReadMovieById(movieId);
        _movies.Remove(findMovie);
        SaveData();
    }

    public void UpdateMovie(Film movie)
    {
        var findMovie = ReadMovieById(movie.Id);
        var index = _movies.IndexOf(findMovie);
        _movies[index] = movie;
        SaveData();
    }

    public Guid WriteMovie(Film movie)
    {
        _movies.Add(movie);
        SaveData();
        return movie.Id;
    }
}
