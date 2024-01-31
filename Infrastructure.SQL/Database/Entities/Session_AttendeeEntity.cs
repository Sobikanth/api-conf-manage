namespace Infrastructure.SQL.Database.Entities;

public class Session_AttendeeEntity
{
    public int Id { get; set; }

    //Navigation properties
    public ICollection<AttendeeEntity> Attendees { get; set; }
    public ICollection<SessionEntity> Sessions { get; set; }
}