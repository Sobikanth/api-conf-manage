namespace Domain.Entities;
public class SessionAttendeeEntity : BaseAuditableEntity
{
    public AttendeeEntity AttendeeEntity { get; set; }
    public SessionEntity SessionEntity { get; set; }
}