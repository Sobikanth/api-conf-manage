using webapi.models;
using Domain.DTOs;

namespace webapi.Mapping.Interfaces;

public interface ILogInModelMapper
{
    public LogInModelDto Map(LogInModel logInModel);
    public LogInModel Map(LogInModelDto logInModelDto);
}