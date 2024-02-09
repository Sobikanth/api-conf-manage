using webapi.models;
using Domain.DTOs;

namespace webapi.Mapping.Interfaces;

public interface IAttendeeMapper
{
    public AttendeeDto Map(Attendee attendee);
    public Attendee Map(AttendeeDto attendeeDto);
}