namespace User.Api.Services.DTOs;

public class UserUpdateDto : BaseUserDto
{
    public Guid Id { get; set; }
    public string Password { get; set; }
}
