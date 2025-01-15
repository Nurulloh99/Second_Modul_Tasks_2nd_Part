using Movie.DataAccess.Entities;
using Movie.Repository.Service;
using Movie.Service.DTOs;

namespace Movie.Service.Service;

public class MovieService : IMovieService
{
    private IRepositoryService _movieRepo;

    public MovieService()
    {
        _movieRepo = new RepositoryService();
    }

    public MovieDto AddMovie(MovieDto movie)
    {
        ValidateMovieCreateDto(movie);
        var newMovie = ConvertToEntity(movie);
        newMovie.Id = Guid.NewGuid();
        _movieRepo.WriteMovie(newMovie);
        return ConvertToDto(newMovie);
    }

    public MovieDto GetMovieById(Guid id)
    {
        var findMovie = _movieRepo.ReadMovieById(id);
        return ConvertToDto(findMovie);
    }

    public List<MovieDto> GetAllMovies()
    {
        return _movieRepo.ReadAllMovies().Select(mv => ConvertToDto(mv)).ToList();
    }

    public void DeleteMovie(Guid movieId)
    {
        _movieRepo.RemoveMovie(movieId);
    }

    public void UpdateMovie(MovieDto movie)
    {
        _movieRepo.UpdateMovie(ConvertToEntity(movie));
    }

    public List<MovieDto> GetAllMoviesByDirector(string director)
    {
        return GetAllMovies().Where(mv => mv.Director == director).ToList();
    }

    public MovieDto GetHighestGrossingMovie()
    {
        var movieLinq = GetAllMovies().Max(mv => mv.BoxOfficeEarnings);
        var allMovies = GetAllMovies().FirstOrDefault(mv => mv.BoxOfficeEarnings == movieLinq);
        return allMovies;
    }

    public List<MovieDto> GetMoviesReleasedAfterYear(int year)
    {
        var allMovies = GetAllMovies().Where(mv => mv.ReleaseDate.Year > year).ToList();
        return allMovies;
    }

    public List<MovieDto> GetMoviesSortedByRating()
    {
        var movies = GetAllMovies();
        var movieList = new List<double>();

        foreach (var movie in movies)
        {
            movieList.Add(movie.Rating);
        }

        var movieGetList = new List<MovieDto>();

        foreach (var movie in movieList)
        {
            foreach (var rateMovie in movies)
            {
                if (rateMovie.Rating == movie)
                {
                    movieGetList.Add(rateMovie);
                    break;
                }
            }
        }

        return movieGetList;
    }

    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        var movieList = GetAllMovies().Where(mv => mv.Rating > minMinutes && mv.Rating < maxMinutes).ToList();
        return movieList;
    }

    public List<MovieDto> GetRecentMovies(int years)
    {
        var movieList = GetAllMovies().Where(mv => object.Equals(mv.ReleaseDate.Year, years)).ToList();
        return movieList;
    }

    public MovieDto GetTopRatedMovie()
    {
        var maxTopMovie = GetAllMovies().Max(mv => mv.Rating);
        var topMovie = GetAllMovies().FirstOrDefault(mv => mv.Rating == maxTopMovie);
        return topMovie;
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        //var moviePriceList = 0l;

        //foreach(var movie in GetAllMovies())
        //{
        //    if(movie.Director == director)
        //    {
        //        moviePriceList += movie.BoxOfficeEarnings;
        //    }
        //}

        //return moviePriceList;

        var moviePriceList = GetAllMovies().Where(mv => mv.Director == director).ToList();
        var movieWithTheSameDirector = moviePriceList.Sum(mv => mv.BoxOfficeEarnings);
        return movieWithTheSameDirector;
    }

    public List<MovieDto> SearchMoviesByTitle(string keyword)
    {
        throw new NotImplementedException();
    }

    private void ValidateMovieCreateDto(MovieDto movie)
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

    private Film ConvertToEntity(MovieDto movie)
    {
        return new Film
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            ReleaseDate = movie.ReleaseDate,
        };
    }


    private MovieDto ConvertToDto(Film movie)
    {
        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            ReleaseDate = movie.ReleaseDate,
        };
    }
}
