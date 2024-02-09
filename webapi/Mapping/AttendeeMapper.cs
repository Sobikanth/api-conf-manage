using webapi.Mapping.Interfaces;
using webapi.models;
using Domain.DTOs;

namespace webapi.Mapping;

public class AttendeeMapper : IAttendeeMapper
{
    public AttendeeDto Map(Attendee attendee)
    {
        return attendee == null ? null : new AttendeeDto
        {
            FirstName = attendee.FirstName,
            LastName = attendee.LastName,
            ContactNumber = attendee.ContactNumber,
            Email = attendee.Email,
            Gender = attendee.Gender
        };
    }

    public Attendee Map(AttendeeDto attendeeDto)
    {
        return attendeeDto == null ? null : new
        Attendee
        {
            FirstName = attendeeDto.FirstName,
            LastName = attendeeDto.LastName,
            ContactNumber = attendeeDto.ContactNumber,
            Email = attendeeDto.Email,
            Gender = attendeeDto.Gender
        };
    }
}