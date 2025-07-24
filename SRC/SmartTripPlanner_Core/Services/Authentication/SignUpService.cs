using System;
using System.Security.Claims;
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
        var userClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier,user.UserName),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.MobilePhone,user.PhoneNumber)
        };
        await _userManager.AddClaimsAsync(user, userClaims);
        return signupResult;
        
    }
}
