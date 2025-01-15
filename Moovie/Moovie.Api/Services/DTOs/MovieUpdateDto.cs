namespace Moovie.Api.Services.DTOs;

public class MovieUpdateDto : BaseMovieDto
{
    public Guid Id { get; set; }
    public long BoxOfficeEarnings { get; set; }
}
