using api_conf_manage.Mapping.Interfaces;
using api_conf_manage.models;
using Domain.Services;
using Infrastructure.SQL.Database;
using Infrastructure.SQL.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api_conf_manage.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ConfContext _confContext;
    private readonly IUserRegisterService _userRegisterService;
    private readonly IUserRegisterModelMapper _userRegisterModelMapper;
    private readonly IUserLogInService _userLogInService;
    private readonly ILogInModelMapper _logInModelMapper;
    public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ConfContext confContext, IUserRegisterModelMapper userRegisterModelMapper, IUserRegisterService userRegisterService, IUserLogInService userLogInService, ILogInModelMapper logInModelMapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _confContext = confContext;
        _userRegisterService = userRegisterService;
        _userRegisterModelMapper = userRegisterModelMapper;
        _userLogInService = userLogInService;
        _logInModelMapper = logInModelMapper;
    }
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterModel userRegisterModel,string? role)
    {
        var result = await _userRegisterService.RegisterAsync(_userRegisterModelMapper.Map(userRegisterModel),role);
        if (result == "User created successfully!")
        {
            return Ok(new Response { Status = "Success", Message = result });
        }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = result });
        }
        /* var userExists = await _userManager.FindByNameAsync(model.Email);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Email
        };
        if (await _roleManager.RoleExistsAsync(role))
        {
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var AttendeeEntity = new AttendeeEntity
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ContactNumber = model.ContactNumber,
                    Email = model.Email,
                    Gender = model.Gender
                };
                await _confContext.Attendees.AddAsync(AttendeeEntity);
                await _confContext.SaveChangesAsync();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            await _userManager.AddToRoleAsync(user, role);
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Role does not exist!" });
        } */
    }
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LogInModel logInModel)
    {
        var result = await _userLogInService.LogInAsync(_logInModelMapper.Map(logInModel));
        if (result != null)
        {
            return Ok(new Response { Status = "Success", Message = result });
        }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User does not exist!" });
        }
    }
}