using MediatR;

namespace Application.Users.Commands.RegisterUser;

public record RegisterUserCommand : IRequest<Guid>
{
    public string UserName { get; init; }
    public string Password { get; init; }
    public string Email { get; init; }
    public string PhoneNumber { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Gender { get; init; }
}