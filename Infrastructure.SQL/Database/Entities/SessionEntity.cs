namespace Infrastructure.SQL.Database.Entities;

public class SessionEntity
{
    //Attributes: ID, Speaker ID, Room ID, Topic, Conf date, Start time, End time
    public int Id { get; set; }
    public string Topic { get; set; }
    public DateTime ConfDate { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    //Navigation properties
    public Session_AttendeeEntity Session_AttendeeEntity { get; set; }
    public RoomEntity RoomEntity { get; set; }
    public SpeakerEntity SpeakerEntity { get; set; }
}