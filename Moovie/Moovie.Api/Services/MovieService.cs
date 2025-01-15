using System.Linq;
using Moovie.Api.DataAccess.Entities;
using Moovie.Api.Repositories;
using Moovie.Api.Services.DTOs;

namespace Moovie.Api.Services;

public class MovieService : IMovieService
{
    public IMovieRepository movieRepo;

    public MovieService()
    {
        movieRepo = new MovieRepository();
    }

    public MovieGetDto AddMovie(MovieCreateDto movie)
    {
        ValidateMovieCreateDto(movie);
        var newMovie = ConvertMovie(movie);
        newMovie.Id = Guid.NewGuid();
        movieRepo.WriteMovie(newMovie);
        return ConvertMovie(newMovie);
    }

    public void DeleteMovie(Guid movieId)
    {
        movieRepo.RemoveMovie(movieId);
    }

    public List<MovieGetDto> GetAllMovies()
    {
        var getAllMovies = movieRepo.ReadAllMovie();
        var allMovies = new List<MovieGetDto>();

        foreach (var movie in getAllMovies)
        {
            allMovies.Add(ConvertMovie(movie));
        }

        return allMovies;
    }

    public List<MovieGetDto> GetAllMoviesByDirector(string director)
    {
        var getAllMovies = movieRepo.ReadAllMovie();
        var allMovies = new List<MovieGetDto>();

        foreach (var movie in getAllMovies)
        {
            if (movie.Director == director)
            {
                allMovies.Add(ConvertMovie(movie));
            }
        }

        return allMovies;
    }

    public MovieGetDto GetHighestGrossingMovie()
    {
        var longest = new MovieGetDto();

        foreach (var movie in GetAllMovies())
        {
            if (movie.BoxOfficeEarnings > longest.BoxOfficeEarnings)
            {
                longest = movie;
            }
        }

        return longest;
    }

    public MovieGetDto GetMovieById(Guid movieId)
    {
        var movieById = movieRepo.ReadMovieById(movieId);
        return ConvertMovie(movieById);
    }

    public List<MovieGetDto> GetMoviesReleasedAfterYear(int year)
    {
        var allMovies = new List<MovieGetDto>();

        foreach (var movie in GetAllMovies())
        {
            if (movie.ReleaseDate.Year > year)
            {
                allMovies.Add(movie);
            }
        }

        return allMovies;
    }

    public List<MovieGetDto> GetMoviesSortedByRating()
    {
        var movies = GetAllMovies();
        var listcha = new List<double>();

        foreach (var movie in movies)
        {
            listcha.Add(movie.Rating);
        }

        listcha.Sort();

        var gettedDtos = new List<MovieGetDto>();

        foreach (var raiting in listcha)
        {
            foreach (var movie in movies)
            {
                if (movie.Rating == raiting)
                {
                    gettedDtos.Add(movie);
                    break;
                }
            }
        }

        return gettedDtos;
    }

    public List<MovieGetDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        var movies = new List<MovieGetDto>();

        foreach(var movie in GetAllMovies())
        {
            if(movie.DurationMinutes > minMinutes && movie.DurationMinutes < maxMinutes)
            {
                movies.Add(movie);
            }
        }

        return movies;
    }

    public List<MovieGetDto> GetRecentMovies(int years)
    {
        var allMovies = new List<MovieGetDto>();

        foreach (var movie in GetAllMovies())
        {
            if (movie.ReleaseDate.Year == years)
            {
                allMovies.Add(movie);
            }
        }

        return allMovies;
    }

    public MovieGetDto GetTopRatedMovie()
    {
        var movie = new MovieGetDto();

        foreach(var moviee in GetAllMovies())
        {
            if(moviee.Rating > movie.Rating)
            {
                movie = moviee;
            }
        }

        return movie;
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        var moviesPrice = 0l;

        foreach (var movie in GetAllMovies())
        {
            if(object.Equals(movie.Director, director))
            {
                moviesPrice += movie.BoxOfficeEarnings;
            }
        }

        return moviesPrice;
    }

    public List<MovieGetDto> SearchMoviesByTitle(string keyword)
    {
        var movies = new List<MovieGetDto>();

        foreach (var movie in GetAllMovies())
        {
            if (movie.Title.Contains(keyword))
            {
                movies.Add(movie);
            }
        }

        return movies;
    }

    public void UpdateMovie(MovieUpdateDto movie)
    {
        movieRepo.UpdateMovie(ConvertMovie(movie));
    }


    public void ValidateMovieCreateDto(MovieCreateDto movie)
    {
        if (string.IsNullOrEmpty(movie.Title) || movie.Title.Length < 1 || movie.Title.Length > 30)
        {
            throw new Exception("Error of Title!");
        }

        if (string.IsNullOrEmpty(movie.Director) || movie.Director.Length < 3 || movie.Director.Length > 30)
        {
            throw new Exception("Error of Director name!");
        }

        if (movie.DurationMinutes < 5 || movie.DurationMinutes > 180)
        {
            throw new Exception("Time Error of Movie!");
        }

        if (movie.Rating < 1 || movie.Rating > 10)
        {
            throw new Exception("Rating Error!");
        }

        if (movie.BoxOfficeEarnings < 1)
        {
            throw new Exception("Budget ERROR of movie!");
        }
    }

    private Film ConvertMovie(MovieCreateDto movieDto)
    {
        return new Film
        {
            Title = movieDto.Title,
            Director = movieDto.Director,
            DurationMinutes = movieDto.DurationMinutes,
            Rating = movieDto.Rating,
            ReleaseDate = movieDto.ReleaseDate,
            BoxOfficeEarnings = movieDto.BoxOfficeEarnings,
        };
    }

    private Film ConvertMovie(MovieUpdateDto movieDto)
    {
        return new Film
        {
            Id = movieDto.Id,
            Title = movieDto.Title,
            Director = movieDto.Director,
            DurationMinutes = movieDto.DurationMinutes,
            Rating = movieDto.Rating,
            ReleaseDate = movieDto.ReleaseDate,
            BoxOfficeEarnings = movieDto.BoxOfficeEarnings,
        };
    }

    private MovieGetDto ConvertMovie(Film movieDto)
    {
        return new MovieGetDto
        {
            Id = movieDto.Id,
            Title = movieDto.Title,
            Director = movieDto.Director,
            DurationMinutes = movieDto.DurationMinutes,
            Rating = movieDto.Rating,
            ReleaseDate = movieDto.ReleaseDate,
        };
    }
}
