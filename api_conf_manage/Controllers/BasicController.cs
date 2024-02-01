using Infrastructure.SQL.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api_conf_manage.Controllers;
[ApiController]
[Route("api/[controller]")]

public class BasicController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ConfContext _confContext;
    public BasicController(UserManager<IdentityUser> userManager, ConfContext confContext)
    {
        _userManager = userManager;
        _confContext = confContext;
    }
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = _userManager.Users.ToList();
        return Ok(users);
    }
    [HttpGet]
    [Authorize(Roles = "RoomCoordinator")]
    [Route("GetAllRooms")]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = _confContext.Rooms.ToList();
        return Ok(rooms);
    }
    [HttpGet]
    [Authorize(Roles = "Speaker")]
    [Route("GetConferenceDates")]
    public async Task<IActionResult> GetConferenceDates()
    {
        var Sessions = _confContext.Sessions.ToList();
        var conferenceDates = Sessions.Select(s => s.ConfDate).Distinct().ToList();
        return Ok(conferenceDates);
    }
}