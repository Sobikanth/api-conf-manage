using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.Users.Commands.RegisterUser;

public class RegisterUserCommandHandler(IIdentityService identityService) : IRequestHandler<RegisterUserCommand, Result>
{
    private readonly IIdentityService _identityService = identityService;

    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.RegisterUserAsync(request.UserName, request.Password, request.PhoneNumber, request.FirstName, request.LastName, request.Gender);

        return result;
    }
}