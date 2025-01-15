namespace Moovie.Api.Services.DTOs;

public class MovieGetDto : BaseMovieDto
{
    public Guid Id { get; set; }
    public long BoxOfficeEarnings { get; set; }
}
