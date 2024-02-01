using api_conf_manage.Mapping.Interfaces;
using api_conf_manage.models;
using Domain.DTOs;

namespace api_conf_manage.Mapping;

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