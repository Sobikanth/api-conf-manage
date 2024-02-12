namespace Domain.Events;

public class RoomCreatedEvent : BaseEvent
{
    public RoomCreatedEvent(RoomEntity room)
    {
        Room = room;
    }

    public RoomEntity Room { get; }
}