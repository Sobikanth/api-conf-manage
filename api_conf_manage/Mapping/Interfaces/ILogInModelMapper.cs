using api_conf_manage.models;
using Domain.DTOs;

namespace api_conf_manage.Mapping.Interfaces;

public interface ILogInModelMapper
{
    public LogInModelDto Map(LogInModel logInModel);
    public LogInModel Map(LogInModelDto logInModelDto);
}