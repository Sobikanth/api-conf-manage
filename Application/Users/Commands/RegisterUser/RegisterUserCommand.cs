using Application.Common.Models;

namespace Application.Users.Commands.RegisterUser;

public record RegisterUserCommand : IRequest<Result>
{
    public string UserName { get; init; }
    public string Password { get; init; }
    public string PhoneNumber { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Gender { get; init; }
}