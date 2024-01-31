namespace Infrastructure.SQL.Database.Entities;

public class Session_Attendee
{
    public int Id;

    //Navigation properties
    public ICollection<AttendeeEntity> Attendees { get; set; }
    public ICollection<SessionEntity> Sessions { get; set; }
}