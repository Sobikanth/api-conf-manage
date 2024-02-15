using Application.Common.Interfaces;

using MediatR;

namespace Application.Users.Commands.RegisterUser;

public class RegisterUserCommandHandler(IIdentityService identityService) : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var (_, userId) = await _identityService.RegisterUserAsync(request.UserName, request.Password, request.PhoneNumber, request.FirstName, request.LastName, request.Gender);

        return userId;
    }
}