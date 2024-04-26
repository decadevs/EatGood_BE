using Eat_Good_Services.Interfaces.Services;
using EatGood_Domain.DTOs;
using EatGood_Domain.ResponseSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eat_Good_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationService;

        public AuthenticationController(IAuthenticationServices authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AppUserCreateDto appUserCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid model state.", StatusCode = StatusCodes.Status400BadRequest });
            }
                       
            var registrationResult = await _authenticationService.RegisterAsync(appUserCreateDto);

            if (registrationResult.IsSuccess)
            {
                return Ok(new { Message = "User registered successfully." });
            }
            else
            {
                return BadRequest(new { Message = registrationResult.ErrorMessage, Errors = registrationResult.Error?.Message });
            }
        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login(AppUserLoginDto loginDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(new Result<string>
                {
                    Content = null,
                    Error = new Error
                    {
                        Message = "Invalid model state.",
                        Type = "errors",
                    },
                    IsSuccess = false
                });
            }

            return Ok(await _authenticationService.LoginAsync(loginDTO));
        }


    }
}
