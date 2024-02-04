using Domain.DTOs;

namespace Domain.Repositories;

public interface IUserRepository
{
    /* Task<string> CreateAttendeeAsync(UserRegisterModelDto userRegisterModelDto);
    Task<string> CreateOrganizerAsync(UserRegisterModelDto userRegisterModelDto, string role); */
    Task<string> CreateUserAsync(UserRegisterModelDto userRegisterModelDto, string role);
}