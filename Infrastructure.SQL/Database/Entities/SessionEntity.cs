namespace Infrastructure.SQL.Database.Entities;

public class SessionEntity
{
    //Attributes: ID, Speaker ID, Room ID, Topic, Conf date, Start time, End time
    public int Id { get; set; }
    public string Topic { get; set; }
    public DateOnly ConfDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    //Navigation properties
    // public Session_AttendeeEntity Session_AttendeeEntity { get; set; }
    public ICollection<Session_AttendeeEntity> Session_AttendeeEntities { get; set; }
    public RoomEntity RoomEntity { get; set; }
    public SpeakerEntity SpeakerEntity { get; set; }
}