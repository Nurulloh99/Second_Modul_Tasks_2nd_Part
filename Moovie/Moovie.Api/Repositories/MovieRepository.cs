using System.Text.Json;
using Moovie.Api.DataAccess.Entities;

namespace Moovie.Api.Repositories;

public class MovieRepository : IMovieRepository
{
    public string _path = "../../../DataAccess/Data/Movies.json";
    private List<Film> _movies;

    public MovieRepository()
    {
        _movies = new List<Film>();

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _movies = ReadAllMovie();
    }

    public void SaveData()
    {
        var movieJson = JsonSerializer.Serialize(_movies);
        File.WriteAllText(_path, movieJson);
    }

    public List<Film> ReadAllMovie()
    {
        var movieResult = File.ReadAllText(_path);
        var movieJson = JsonSerializer.Deserialize<List<Film>>(movieResult);
        return movieJson;
    }

    public Film ReadMovieById(Guid movieId)
    {
        foreach (var movie in _movies)
        {
            if (movie.Id == movieId)
            {
                return movie;
            }
        }

        return null;
    }

    public void RemoveMovie(Guid movieId)
    {
        var removingMovie = ReadMovieById(movieId);
        _movies.Remove(removingMovie);
        SaveData();
    }

    public void UpdateMovie(Film movie)
    {
        var updatingMovie = ReadMovieById(movie.Id);
        var index = _movies.IndexOf(updatingMovie);
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
