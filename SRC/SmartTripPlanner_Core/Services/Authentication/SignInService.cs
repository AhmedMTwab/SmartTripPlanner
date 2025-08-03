using System;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartTripPlanner_Core.DTOs;


public class SignInService(UserManager<ApplicationUser> _userManager,IConfiguration _configuration) : ISignInService
{
    public async Task<TokenDTO> SignInAsync(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        string securityKey=_configuration.GetSection("SecurityKey").Value;
        byte[] keyBytes = ASCIIEncoding.ASCII.GetBytes(securityKey);
        var key = new SymmetricSecurityKey(keyBytes);
        var methodUsedInGeneratingToken = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var exp = DateTime.Now.AddDays(1);
        var token = new JwtSecurityToken(
            claims: userClaims,
            signingCredentials: methodUsedInGeneratingToken,
            notBefore: DateTime.Now,
            expires: exp
        );
        var Handler=new JwtSecurityTokenHandler();
        var tokenResult=Handler.WriteToken(token);
        return new TokenDTO() { Token = tokenResult ,Expire_Date=exp};

    }
}
