using System;
using System.Data;
using FluentValidation;

namespace SmartTripPlanner_Core.DTOs.DTOsValidation;

public class SignUpDTOValidation:AbstractValidator<SignUpDTO>
{
    public SignUpDTOValidation()
    {
        RuleFor(s => s.Username).Length(5, 15);
        RuleFor(s => s.Email).EmailAddress();
        RuleFor(s => s.Password).Length(8, 20);
        RuleFor(s => s.ConfirmPassword).Equal(s => s.Password);
    }
}
