using webapi.Mapping.Interfaces;
using webapi.models;
using Domain.DTOs;

namespace webapi.Mapping;

public class LogInModelMapper : ILogInModelMapper
{
    public LogInModelDto Map(LogInModel logInModel)
    {
        return new LogInModelDto
        {
            Email = logInModel.Email,
            Password = logInModel.Password
        };
    }

    public LogInModel Map(LogInModelDto logInModelDto)
    {
        return new LogInModel
        {
            Email = logInModelDto.Email,
            Password = logInModelDto.Password
        };
    }
}