using api_conf_manage.Mapping.Interfaces;
using api_conf_manage.models;
using Domain.DTOs;

namespace api_conf_manage.Mapping;

public class UserRegisterModelMapper : IUserRegisterModelMapper
{
    public UserRegisterModelDto Map(UserRegisterModel userRegisterModel)
    {
        return new UserRegisterModelDto
        {
            Username = userRegisterModel.Username,
            Password = userRegisterModel.Password,
            FirstName = userRegisterModel.FirstName,
            LastName = userRegisterModel.LastName,
            ContactNumber = userRegisterModel.ContactNumber,
            Gender = userRegisterModel.Gender,
            Email = userRegisterModel.Email
        };
    }

    public UserRegisterModel Map(UserRegisterModelDto userRegisterModelDto)
    {
        return new UserRegisterModel
        {
            Username = userRegisterModelDto.Username,
            Password = userRegisterModelDto.Password,
            FirstName = userRegisterModelDto.FirstName,
            LastName = userRegisterModelDto.LastName,
            ContactNumber = userRegisterModelDto.ContactNumber,
            Gender = userRegisterModelDto.Gender,
            Email = userRegisterModelDto.Email
        };
    }
}