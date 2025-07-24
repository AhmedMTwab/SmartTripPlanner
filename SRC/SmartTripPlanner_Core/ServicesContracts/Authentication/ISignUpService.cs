using System;
using Microsoft.AspNetCore.Identity;

namespace SmartTripPlanner_Core.ServicesContracts.Authentication;

public interface ISignUpService
{
    public Task<IdentityResult> SignUpAsync(SignUpDTO signUpDTO);
}
