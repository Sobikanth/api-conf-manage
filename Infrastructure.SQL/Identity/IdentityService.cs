using Application.Common.Interfaces;
using Application.Common.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Identity;

public class IdentityService(
    UserManager<ApplicationUser> userManager,
    IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
    IAuthorizationService authorizationService) : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService = authorizationService;

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<(Result Result, Guid UserId)> RegisterUserAsync(string userName, string password, string phoneNumber, string firstName, string lastName, string gender)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
            PhoneNumber = phoneNumber,
            FirstName = firstName,
            LastName = lastName,
            Gender = gender
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), new Guid(user.Id));
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AddToRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var result = await _userManager.AddToRoleAsync(user, role);

        return result.Succeeded;
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<(Result result, string token)> LoginUserAsync(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user == null)
        {
            return (Result.Failure(new[] { "User does not exist." }), null);
        }

        var result = await _userManager.CheckPasswordAsync(user, password);

        if (!result)
        {
            return (Result.Failure(new[] { "Invalid password." }), null);
        }

        var token = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "passwordless-auth");

        return (Result.Success(), token);
    }
}