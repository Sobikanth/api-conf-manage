// using System.Security.Claims;
// using Infrastructure.SQL.Database;
// using Infrastructure.SQL.Database.Entities;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;

// namespace webapi.Controllers;
// [ApiController]
// [Route("api/[controller]")]

// public class BasicController : ControllerBase
// {
//     private readonly UserManager<IdentityUser> _userManager;
//     private readonly ConfContext _confContext;
//     public BasicController(UserManager<IdentityUser> userManager, ConfContext confContext)
//     {
//         _userManager = userManager;
//         _confContext = confContext;
//     }
//     [HttpGet]
//     [Authorize(Roles = "Admin")]
//     [Route("GetAllUsers")]
//     public async Task<IActionResult> GetAllUsers()
//     {
//         var users = _userManager.Users.ToList();
//         return Ok(users);
//     }
//     [HttpGet]
//     [Authorize(Roles = "RoomCoordinator")]
//     [Route("GetAllRooms")]
//     public async Task<IActionResult> GetAllRooms()
//     {
//         var rooms = _confContext.Rooms.ToList();
//         return Ok(rooms);
//     }
//     [HttpGet]
//     [Authorize(Roles = "Speaker")]
//     [Route("GetConferenceDates")]
//     public async Task<IActionResult> GetConferenceDates()
//     {
//         var Sessions = _confContext.Sessions.ToList();
//         var conferenceDates = Sessions.Select(s => s.ConfDate).Distinct().ToList();
//         return Ok(conferenceDates);
//     }

//     /* [HttpGet]
//     [Authorize(Roles = "Attendee")]
//     [Route("GetUser")]
//     public async Task<IActionResult> GetUser()
//     {
//         var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
//         string userName = User.FindFirstValue(ClaimTypes.Name);
//         IEnumerable<Claim> claims = User.Claims;
//         return Ok(claims);
//     } */

//     /* [HttpGet]
//     [Authorize(Roles = "Attendee")]
//     [Route("GetAllSessions")]
//     public async Task<IActionResult> GetAllSessions()
//     {
//         var sessions = _confContext.Sessions.ToList();
//         return Ok(sessions);
//     }
//  */
//     /* [HttpGet]
//     [Authorize(Roles = "Attendee")]
//     [Route("RegisterForSession")]
//     public async Task<IActionResult> RegisterForSession(string sessionId)
//     {
//         try
//         {
//             string userName = User.FindFirstValue(ClaimTypes.Name);
//             var attendeeEntity = _confContext.Attendees.FirstOrDefault(u => u.Email == userName);
//             var session = _confContext.Sessions.FirstOrDefault(s => s.SessionId == Guid.Parse(sessionId));
//             var sessionAttendee = new Session_AttendeeEntity
//             {
//                 SessionEntity = session,
//                 AttendeeEntity = attendeeEntity
//             };
//             _confContext.Session_AttendeeEntities.Add(sessionAttendee);
//             _confContext.SaveChanges();
//             return Ok("Registered successfully");
//         }
//         catch (Exception e)
//         {
//             return BadRequest(e.Message);
//         }
//     } */

//     /* [HttpGet]
//     [Authorize(Roles = "Attendee")]
//     [Route("GetRegisteredSessions")]
//     public async Task<IActionResult> GetRegisteredSessions()
//     {
//         try
//         {
//             string userName = User.FindFirstValue(ClaimTypes.Name);
//             var userId = _confContext.Attendees.FirstOrDefault(u => u.Email == userName).AttendeeId;
//             var sessions = _confContext.Session_AttendeeEntities.Where(s => s.AttendeeEntity.AttendeeId == userId).Select(s => s.SessionEntity).ToList();
//             return Ok(sessions);
//         }
//         catch (Exception e)
//         {
//             return BadRequest(e.Message);
//         }
//     } */
// }