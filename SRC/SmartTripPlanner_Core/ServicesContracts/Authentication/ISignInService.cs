using System;
using Microsoft.AspNetCore.Identity;
using SmartTripPlanner_Core.DTOs;


public interface ISignInService
{
    public Task<TokenDTO> SignInAsync(ApplicationUser user);
}
