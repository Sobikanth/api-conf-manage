using api_conf_manage.Mapping.Interfaces;
using api_conf_manage.models;
using Domain.Services;
using FluentValidation;
using Infrastructure.SQL.Database;
using Infrastructure.SQL.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api_conf_manage.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    /* private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ConfContext _confContext; */
    private readonly IUserRegisterService _userRegisterService;
    private readonly IUserRegisterModelMapper _userRegisterModelMapper;
    private readonly IUserLogInService _userLogInService;
    private readonly ILogInModelMapper _logInModelMapper;
    private readonly IValidator<UserRegisterModel> _userValidator;
    public AuthenticationController(IUserRegisterModelMapper userRegisterModelMapper, IUserRegisterService userRegisterService, IUserLogInService userLogInService, ILogInModelMapper logInModelMapper, IValidator<UserRegisterModel> userValidator)
    {
        /* _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _confContext = confContext; */
        _userRegisterService = userRegisterService;
        _userRegisterModelMapper = userRegisterModelMapper;
        _userLogInService = userLogInService;
        _logInModelMapper = logInModelMapper;
        _userValidator = userValidator;
    }
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterModel userRegisterModel, string? role)
    {
        var validationResult = _userValidator.Validate(userRegisterModel);
        if (validationResult.IsValid)
        {
            var result = await _userRegisterService.RegisterAsync(_userRegisterModelMapper.Map(userRegisterModel), role);
            if (result == "User created successfully!")
            {
                return Ok(new Response { Status = "Success", Message = result });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = result });
            }
        }
        return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
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