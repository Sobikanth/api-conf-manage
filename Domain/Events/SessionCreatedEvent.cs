namespace Domain.Events;

public class SessionCreatedEvent : BaseEvent
{
    public SessionCreatedEvent(SessionEntity session)
    {
        Session = session;
    }
    public SessionEntity Session { get; }
}