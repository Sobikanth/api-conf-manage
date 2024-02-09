using System.Security.Claims;
using Infrastructure.SQL.Database;
using Infrastructure.SQL.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers;
[ApiController]
[Route("api/[controller]")]

public class SessionsController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ConfContext _confContext;
    public SessionsController(UserManager<IdentityUser> userManager, ConfContext confContext)
    {
        _userManager = userManager;
        _confContext = confContext;
    }
    [HttpGet]
    [Authorize(Roles = "Admin, Speaker, RoomCoordinator, Attendee")]
    [Route("GetAllSessions")]
    public async Task<IActionResult> GetAllSessions()
    {
        // var sessions = await _confContext.Sessions.ToListAsync();
        var sessions = await _confContext.Sessions.Select(s => new
        {
            Id = s.SessionId,
            s.Topic,
            Date = s.ConfDate.ToString("dd/MM/yyyy"),
            Time = s.StartTime.ToString("hh:mm tt") + " - " + s.EndTime.ToString("hh:mm tt"),
            SpeakerName = "Speaker is: " + s.SpeakerEntity.FirstName + " " + s.SpeakerEntity.LastName,
        }).ToListAsync();
        return Ok(sessions);
    }

    [HttpGet]
    [Authorize(Roles = "Attendee")]
    [Route("RegisterForSession")]
    public async Task<IActionResult> RegisterForSession(string sessionId)
    {
        try
        {
            string userName = User.FindFirstValue(ClaimTypes.Name);
            var attendeeEntity = _confContext.Attendees.FirstOrDefault(u => u.Email == userName);
            var session = _confContext.Sessions.FirstOrDefault(s => s.SessionId == Guid.Parse(sessionId));
            var sessionAttendee = new Session_AttendeeEntity
            {
                SessionEntity = session,
                AttendeeEntity = attendeeEntity
            };
            await _confContext.Session_AttendeeEntities.AddAsync(sessionAttendee);
            _confContext.SaveChanges();
            return Ok("Registered successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Authorize(Roles = "Attendee")]
    [Route("GetRegisteredSessions")]
    public async Task<IActionResult> GetRegisteredSessions()
    {
        try
        {
            string userName = User.FindFirstValue(ClaimTypes.Name);
            var attendee = await _confContext.Attendees.FirstOrDefaultAsync(u => u.Email == userName);
            var userId = attendee.AttendeeId;
            var sessions = await _confContext.Session_AttendeeEntities.Where(s => s.AttendeeEntity.AttendeeId == userId).Select(s => new
            {
                s.SessionEntity.Topic,
                Date = s.SessionEntity.ConfDate.ToString("dd/MM/yyyy"),
                Time = s.SessionEntity.StartTime.ToString("hh:mm tt") + " - " + s.SessionEntity.StartTime.ToString("hh:mm tt"),
                SpeakerName = s.SessionEntity.SpeakerEntity.FirstName + " " + s.SessionEntity.SpeakerEntity.LastName,
            }).ToListAsync();
            return Ok(sessions);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}