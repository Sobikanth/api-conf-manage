namespace Domain.Events;

public class SessionCreatedEvent(SessionEntity session) : BaseEvent
{
    public SessionEntity Session { get; } = session;
}