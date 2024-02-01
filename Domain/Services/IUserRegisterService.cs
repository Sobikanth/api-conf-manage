using Domain.DTOs;

namespace Domain.Services;

public interface IUserRegisterService
{
    Task<string> RegisterAsync(UserRegisterModelDto userRegisterModelDto,string role);
}