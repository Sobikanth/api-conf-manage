using System.ComponentModel.DataAnnotations;

namespace Infrastructure.SQL.Database.Entities;

public class OrganizerEntity
{
    //populate this class with the properties from the Admin table in the database
    // public int Id { get; set; }
    [Key]
    public Guid OrganizerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
}