namespace Moovie.Api.Services.DTOs;

public class BaseMovieDto
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int DurationMinutes { get; set; }
    public double Rating { get; set; }
    public DateTime ReleaseDate { get; set; }
}
