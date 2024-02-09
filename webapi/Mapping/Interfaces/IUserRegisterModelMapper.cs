using webapi.models;
using Domain.DTOs;

namespace webapi.Mapping.Interfaces;

public interface IUserRegisterModelMapper
{
    public UserRegisterModelDto Map(UserRegisterModel userRegisterModel);
    public UserRegisterModel Map(UserRegisterModelDto userRegisterModelDto);
}