using api_conf_manage.models;
using Domain.DTOs;

namespace api_conf_manage.Mapping.Interfaces;

public interface IAttendeeMapper
{
    public AttendeeDto Map(Attendee attendee);
    public Attendee Map(AttendeeDto attendeeDto);
}