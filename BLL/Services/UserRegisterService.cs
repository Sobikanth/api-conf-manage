using Domain.DTOs;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BLL.Services;

public class UserRegisterService : IUserRegisterService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    public UserRegisterService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IUserRepository userRepository)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _userRepository = userRepository;
    }
    public async Task<string> RegisterAsync(UserRegisterModelDto userRegisterModelDto,string role)
    {
        var userExists = await _userManager.FindByNameAsync(userRegisterModelDto.Email);
        if (userExists != null)
            return "User already exists!";
        IdentityUser user = new()
        {
            Email = userRegisterModelDto.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = userRegisterModelDto.Email
        };
        if (await _roleManager.RoleExistsAsync(role))
        {
            var result = await _userManager.CreateAsync(user, userRegisterModelDto.Password);
            if (result.Succeeded)
            {
                if (role == "User")
                {
                    await _userRepository.CreateAttendeeAsync(userRegisterModelDto);
                }
                else if (role == "Admin")
                {
                    return "You are not authorized to create an Admin!";
                }
            }
            else
            {
                return "User creation failed! Please check user details and try again.";
            }
            await _userManager.AddToRoleAsync(user, role);
            return "User created successfully!";
        }
        else
        {
            return "Role does not exist!";
        }
    }
}