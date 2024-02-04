using System.ComponentModel.DataAnnotations;

namespace Infrastructure.SQL.Database.Entities;

public class Session_AttendeeEntity
{
    // public int Id { get; set; }
    [Key]
    public Guid Session_AttendeeId { get; set; }
    // public string Topic { get; set; }

    //Navigation properties

    public AttendeeEntity AttendeeEntity { get; set; }

    public SessionEntity SessionEntity { get; set; }
}