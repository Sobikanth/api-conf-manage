using Domain.DTOs;
using Domain.Repositories;
using Infrastructure.SQL.Database;
using Infrastructure.SQL.Database.Entities;

namespace Infrastructure.SQL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ConfContext _confContext;
    public UserRepository(ConfContext confContext)
    {
        _confContext = confContext;
    }
    public async Task<int> CreateAttendeeAsync(UserRegisterModelDto userRegisterModelDto)
    {
        var AttendeeEntity = new AttendeeEntity
        {
            FirstName = userRegisterModelDto.FirstName,
            LastName = userRegisterModelDto.LastName,
            ContactNumber = userRegisterModelDto.ContactNumber,
            Email = userRegisterModelDto.Email,
            Gender = userRegisterModelDto.Gender
        };
        await _confContext.Attendees.AddAsync(AttendeeEntity);
        await _confContext.SaveChangesAsync();
        return AttendeeEntity.Id;
    }
    public async Task<int> CreateOrganizerAsync(UserRegisterModelDto userRegisterModelDto)
    {
        var OrganizerEntity = new OrganizerEntity
        {
            FirstName = userRegisterModelDto.FirstName,
            LastName = userRegisterModelDto.LastName,
            ContactNumber = userRegisterModelDto.ContactNumber,
            Email = userRegisterModelDto.Email,
            Gender = userRegisterModelDto.Gender
        };
        await _confContext.Organizers.AddAsync(OrganizerEntity);
        await _confContext.SaveChangesAsync();
        return OrganizerEntity.Id;
    }
}