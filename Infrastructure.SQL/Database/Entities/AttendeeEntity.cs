using System.ComponentModel.DataAnnotations;

namespace Infrastructure.SQL.Database.Entities;

public class AttendeeEntity
{
    // public int Id { get; set; }
    [Key]
    public Guid AttendeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    //Navigation properties
    // public Session_AttendeeEntity Session_AttendeeEntity { get; set; }
    public ICollection<Session_AttendeeEntity> Session_AttendeeEntities { get; set; }

    //generate something like this
    /* {
        "Username": "Vijay@gmail.com",
        "Password": "Vijay@1234",
        "FirstName": "Vijay",
        "LastName": "Thalapathy",
        "ContactNumber": "1234456789",
        "Gender": "Male",
        "Email": "Vijay@gmail.com"
    } */
}
