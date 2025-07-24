using System;
using Microsoft.AspNetCore.Identity;

namespace SmartTripPlanner_Core.ServicesContracts.Authentication;

public class SignUpService(UserManager<ApplicationUser> _userManager) : ISignUpService
{
    public async Task<IdentityResult> SignUpAsync(SignUpDTO signUpDTO)
    {

        var user = new ApplicationUser
        {
            UserName = signUpDTO.Username,
            Email = signUpDTO.Email,
            PhoneNumber = signUpDTO.PhoneNumber
        };
        var signupResult = await _userManager.CreateAsync(user, signUpDTO.Password);
        return signupResult;
        
    }
}
