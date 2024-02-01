namespace Domain.DTOs;

public class UserRegisterModelDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactNumber { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
}