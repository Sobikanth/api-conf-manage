using System.Text.RegularExpressions;
using api_conf_manage.models;
using FluentValidation;
using FluentValidation.Results;

namespace api_conf_manage.Validators;

public class UserValidator : AbstractValidator<UserRegisterModel>
{
    public UserValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required").Matches(@"^[a-zA-Z\s]*$").WithMessage("First Name must contain only alphabets").MaximumLength(50).WithMessage("First Name must be less than 50 characters");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required").Matches(@"^[a-zA-Z\s]*$").WithMessage("Last Name must contain only alphabets").MaximumLength(50).WithMessage("Last Name must be less than 50 characters");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email Address").NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.ContactNumber).Matches(@"^\d{10}$").WithMessage("Contact Number must be a 10-digit number");
    }
}