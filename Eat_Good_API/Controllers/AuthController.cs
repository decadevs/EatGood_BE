using Eat_Good_Services.Interfaces;
using EatGood_Domain.DTOs;
using EatGood_Domain.ResponseSystem;
using Microsoft.AspNetCore.Mvc;

namespace Eat_Good_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationServices _authentication;

        public AuthController(IAuthenticationServices authentication) 
        {
            _authentication = authentication;
        }



        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AppUserCreateDto appUserCreateDto)
        {
            if (!ModelState.IsValid)
            {
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

            // Call registration service
            return Ok(await _authentication.RegisterAsync(appUserCreateDto));
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

            return Ok(await _authentication.LoginAsync(loginDTO));
        }





    }
}
