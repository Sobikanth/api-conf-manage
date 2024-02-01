using Domain.DTOs;

namespace Domain.Services;

public interface IUserLogInService
{
    Task<string> LogInAsync(LogInModelDto logInModelDto);
}