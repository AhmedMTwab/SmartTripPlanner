using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartTripPlanner_Core.DTOs;
using SmartTripPlanner_Core.ServicesContracts.Authentication;

namespace SmartTripPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(UserManager<ApplicationUser> _userManager, ISignUpService _signUpService, ISignInService _signInService,IDeleteAccountService _deleteAccountService) : ControllerBase
    {
        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(SignUpDTO signUpDTO)
        {
            if (signUpDTO == null)
            {
                return BadRequest("SignUp data is Empty");
            }
            var isUser = await _userManager.FindByNameAsync(signUpDTO.Username);
            if (isUser != null)
            {
                return BadRequest("Username already exists");
            }
            var signupResult = await _signUpService.SignUpAsync(signUpDTO);
            if (!signupResult.Succeeded)
            {
                return BadRequest(signupResult.Errors);
            }
            return Ok("Added Succesfully");
        }


        [HttpPost("SignIn")]
        public async Task<ActionResult<TokenDTO>> SignIn(SignInDTO signInDTO)
        {
            if (signInDTO == null)
            {
                return BadRequest("SignUp data is Empty");
            }
            var user = await _userManager.FindByNameAsync(signInDTO.Username);
            if (user != null)
            {
                var isLockedout = await _userManager.IsLockedOutAsync(user);
                if (isLockedout)
                {
                    var lockoutTime = await _userManager.GetLockoutEndDateAsync(user);
                    return BadRequest($"user locked out till {lockoutTime}");
                }
                var checkPassworrd = await _userManager.CheckPasswordAsync(user, signInDTO.Password);
                if (!checkPassworrd)
                {
                    await _userManager.AccessFailedAsync(user);
                    return Unauthorized("Wrong Password");
                }
                var token = await _signInService.SignInAsync(user);
                return Ok(token);
            }
            else
                return BadRequest("Wrong UserName");
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAccount(string AccountID)
        {
            var result = await _deleteAccountService.DeleteAccountAsync(AccountID);
            if (result)
                return Ok("Account Deleted");

            return NotFound("Account NotFound");
        }
    }
}
