using api_conf_manage.models;
using Domain.DTOs;

namespace api_conf_manage.Mapping.Interfaces;

public interface IUserRegisterModelMapper
{
    public UserRegisterModelDto Map(UserRegisterModel userRegisterModel);
    public UserRegisterModel Map(UserRegisterModelDto userRegisterModelDto);
}