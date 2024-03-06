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
        try
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Result> RegisterUserAsync(string userName, string password, string phoneNumber, string firstName, string lastName, string gender)
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

        return result.ToApplicationResult();
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<List<string>> GetUserAsync(string userId)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return [];
        }
        else
        {
            var userInfo = new List<string>();

            if (user != null)
            {
                userInfo.Add(user.UserName ?? string.Empty);
                userInfo.Add(user.PhoneNumber ?? string.Empty);
                userInfo.Add(user.FirstName ?? string.Empty);
                userInfo.Add(user.LastName ?? string.Empty);
                userInfo.Add(user.Gender ?? string.Empty);
            }

            return userInfo;
        }
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

    public async Task<string?> GetUserIdAsync(string userName, string password)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.UserName == userName);
        return user != null && await _userManager.CheckPasswordAsync(user, password) ? user.Id : null;
    }

    public async Task<List<string>> GetUserRolesAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? [.. (await _userManager.GetRolesAsync(user))] : [];
    }
}