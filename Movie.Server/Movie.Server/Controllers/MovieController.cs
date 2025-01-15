using Microsoft.AspNetCore.Mvc;
using Movie.Service.DTOs;
using Movie.Service.Service;

namespace Movie.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;

        public MovieController()
        {
            _movieService = new MovieService();
        }

        [HttpPost("Add movie")]

        public MovieDto AddMovie(MovieDto movie)
        {
            return _movieService.AddMovie(movie);
        }


        [HttpGet("Get movies By Id")]

        public MovieDto GetMovieById(Guid movieId)
        {
            return _movieService.GetMovieById(movieId);
        }


        [HttpGet("Get all movies")]

        public List<MovieDto> GetAllMovies()
        {
            return _movieService.GetAllMovies();
        }


        [HttpPost("Delete movie")]

        public void DeleteMovie(Guid movieId)
        {
            _movieService.DeleteMovie(movieId);
        }


        [HttpPost("Update movie")]

        public void UpdateMovie(MovieDto movieId)
        {
            _movieService.UpdateMovie(movieId);
        }


        [HttpGet("Get All Movies By Director")]

        public List<MovieDto> GetAllMoviesByDirector(string director)
        {
            return _movieService.GetAllMoviesByDirector(director);
        }


        [HttpGet("Get Top Rated Movie")]

        public MovieDto GetTopRatedMovie()
        {
            return _movieService.GetTopRatedMovie();
        }


        [HttpGet("Get Movies Released After Year")]

        public List<MovieDto> GetMoviesReleasedAfterYear(int year)
        {
            return _movieService.GetMoviesReleasedAfterYear(year);
        }


        [HttpGet("Get Highest Grossing Movie")]

        public MovieDto GetHighestGrossingMovie()
        {
            return _movieService.GetHighestGrossingMovie();
        }


        [HttpGet("Search Movies By Title")]

        public List<MovieDto> SearchMoviesByTitle(string keyword)
        {
            return _movieService.SearchMoviesByTitle(keyword);
        }


        [HttpGet("Get Movies Within Duration Range")]

        public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
        {
            return _movieService.GetMoviesWithinDurationRange(minMinutes, maxMinutes);
        }


        [HttpGet("Get Total Box Office Earnings By Director")]

        public long GetTotalBoxOfficeEarningsByDirector(string director)
        {
            return _movieService.GetTotalBoxOfficeEarningsByDirector(director);
        }


        [HttpGet("Get Movies Sorted By Rating")]

        public List<MovieDto> GetMoviesSortedByRating()
        {
            return _movieService.GetMoviesSortedByRating();
        }


        [HttpGet("Get Recent Movies")]

        public List<MovieDto> GetRecentMovies(int years)
        {
            return _movieService.GetRecentMovies(years);
        }
    }
}
