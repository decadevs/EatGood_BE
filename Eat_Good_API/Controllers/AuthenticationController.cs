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
               // return BadRequest(Result<string>.Failed("Invalid model state.", StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
                return BadRequest(Result<string>
                {
                    IsSuccess = false,
                    ErrorMessage = "User with this phone number already exists.",
                    Content = null,
                    StatusCode = StatusCodes.Status400BadRequest

                });
            }

            // Call registration service
            var registrationResult = await _authenticationService.RegisterAsync(appUserCreateDto);



            if (registrationResult.Succeeded)
            {
                var data = registrationResult.Data;
                //  _backgroundJobClient.Enqueue(() => Console.WriteLine(data));
                var confirmationLink = GenerateConfirmEmailLink(data.Id, data.Token);
                return Ok(await _emailServices.SendEmailAsync(confirmationLink, data.Email, data.Id));
            }
            else
            {
                return BadRequest(new { Message = registrationResult.Message, Errors = registrationResult.Errors });
            }
        }
    }
}
