using Domain.DTOs;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<int> CreateAttendeeAsync(UserRegisterModelDto userRegisterModelDto);
    Task<int> CreateOrganizerAsync(UserRegisterModelDto userRegisterModelDto);
}