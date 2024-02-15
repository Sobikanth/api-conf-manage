using Application.Common.Models;

namespace Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);
    Task<string?> GetUserIdAsync(string userName, string password);
    Task<List<string>> GetUserRolesAsync(string userId);
    Task<bool> IsInRoleAsync(string userId, string role);
    Task<bool> AddToRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, Guid UserId)> RegisterUserAsync(string userName, string password, string phoneNumber, string firstName, string lastName, string gender);

    // Task<(Result result, string token)> LoginUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);
}