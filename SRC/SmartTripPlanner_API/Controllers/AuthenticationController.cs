using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartTripPlanner_Core.ServicesContracts.Authentication;

namespace SmartTripPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(UserManager<ApplicationUser> _userManager,ISignUpService _signUpService) : ControllerBase
    {
        [HttpPost("SignUp")]
        public async Task<ActionResult<bool>> SignUp(SignUpDTO signUpDTO)
        {
            if (signUpDTO == null)
            {
                return BadRequest("SignUp data is Empty");
            }
            var isUser=await _userManager.FindByNameAsync(signUpDTO.Username);
            if(isUser != null)
            {
                return BadRequest("Username already exists");
            }
            var signupResult =await  _signUpService.SignUpAsync(signUpDTO);
            if (!signupResult.Succeeded)
            {
                return BadRequest(signupResult.Errors);
            }
            return Ok("Signed Succesfully");
        }
    }
}
