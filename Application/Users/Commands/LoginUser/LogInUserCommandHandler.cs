// using Application.Common.Interfaces;
// using Application.Common.Models;
// using MediatR;

// namespace Application.Users.Commands.LoginUser;

// public class LogInUserCommandHandler : IRequestHandler<LoginUserCommand, string>
// {
//     private readonly IIdentityService _identityService;

//     public LogInUserCommandHandler(IIdentityService identityService)
//     {
//         _identityService = identityService;
//     }
//     public async Task<token> Handle(LoginUserCommand request, CancellationToken cancellationToken)
//     {
//         var (_, token) = await _identityService.LoginUserAsync(request.UserName, request.Password);
//         return token;
//     }
// }
