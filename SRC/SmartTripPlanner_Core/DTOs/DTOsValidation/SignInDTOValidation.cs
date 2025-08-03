using System;
using FluentValidation;
using SmartTripPlanner_Core.DTOs;


public class SignInDTOValidation : AbstractValidator<SignInDTO>
{
    public SignInDTOValidation()
    {
        RuleFor(s => s.Username).Length(5, 15);
    }

}
