using Eat_Good_Data.Repositories.Generic.Implementation;
using Eat_Good_Data.Repositories.Generic.Interface;
using Eat_Good_Services.Interfaces.Services;
using EatGood_Domain.DTOs;
using EatGood_Domain.Entities;
using EatGood_Domain.ResponseSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Eat_Good_Services.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUnitOfWork _unitOfWork;        
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AuthenticationServices> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;

        public AuthenticationServices(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, ILogger<AuthenticationServices> logger, SignInManager<AppUser> signInManager, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            
            _config = config;
        }
        public async Task<Result<RegisterResponseDto>> RegisterAsync(AppUserCreateDto appUserCreateDto)
        {
            var user = await _userManager.FindByEmailAsync(appUserCreateDto.Email);
            if (user != null)
            {
                return new Result<RegisterResponseDto>
                {
                    IsSuccess = false,
                    ErrorMessage = "User with this email already exists.",
                    StatusCode = StatusCodes.Status409Conflict,
                    Content = null
                };
            }

            var userr = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(x => x.PhoneNumber == appUserCreateDto.PhoneNumber);
            if (userr != null)
            {
                return new Result<RegisterResponseDto>
                {
                    IsSuccess = false,
                    ErrorMessage = "User with this phone number already exists.",
                    Content = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            var appUser = new AppUser()
            {
                FirstName = appUserCreateDto.FirstName,
                LastName = appUserCreateDto.LastName,
                Email = appUserCreateDto.Email,
                PhoneNumber = appUserCreateDto.PhoneNumber,
                UserName = appUserCreateDto.Email,
                //PasswordResetToken = ""
            };
            try
            {
                //var token = "";

                var result = await _userManager.CreateAsync(appUser, appUserCreateDto.Password);


                if (result.Succeeded)
                {
                    var response = new RegisterResponseDto
                    {
                        Id = appUser.Id,
                        Email = appUser.Email,
                        PhoneNumber = appUser.PhoneNumber,
                        FirstName = appUser.FirstName,
                        LastName = appUser.LastName,
                        //Token = token
                    };



                    return new Result<RegisterResponseDto>
                    {
                        IsSuccess = true,
                        ErrorMessage = "User created successfully.",
                        Content = response,
                        StatusCode = StatusCodes.Status201Created
                    };
                }
                else
                {
                    await _unitOfWork.UserRepository.DeleteAsync(appUser);
                    return new Result<RegisterResponseDto>
                    {
                        IsSuccess = false,
                        ErrorMessage = "Unable to create user with the given email.",
                        Content = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a manager " + ex.InnerException);
                return new Result<RegisterResponseDto> { IsSuccess = false, ErrorMessage = "Error occured while creating user", Content = null, StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

         

        public async Task<Result<LoginResponseDto>> LoginAsync(AppUserLoginDto loginDto)
        {
            try
            {
                // Find user by email
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null)
                {
                    return new Result<LoginResponseDto>
                    {
                        IsSuccess = false,
                        ErrorMessage = "Invalid email or password.",
                        StatusCode = StatusCodes.Status401Unauthorized,
                        Content = null
                    };
                }

                 
                // Check if the provided password is correct
                var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Retrieve the user's role
                    var roles = await _userManager.GetRolesAsync(user);
                    var role = roles.FirstOrDefault();

                    // Generate JWT token
                    var token = GenerateJwtToken(user);

                    var response = new LoginResponseDto
                    {
                        JWToken = token
                    };

                    return new Result<LoginResponseDto>
                    {
                        IsSuccess = true,
                        Message = "Login successful.",
                        StatusCode = StatusCodes.Status200OK,
                        Content = response
                    };
                }
                else
                {
                    return new Result<LoginResponseDto>
                    {
                        IsSuccess = false,
                        ErrorMessage = "Invalid email or password.",
                        StatusCode = StatusCodes.Status401Unauthorized,
                        Content = null
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging in.");
                return new Result<LoginResponseDto>
                {
                    IsSuccess = false,
                    ErrorMessage = "An error occurred while logging in.",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Content = null
                };
            }
        }
         

        private string GenerateJwtToken(AppUser contact)
        {
            var jwtSettings = _config.GetSection("JwtSettings:Secret").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, contact.Id),
                new Claim(JwtRegisteredClaimNames.Email, contact.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, contact.FirstName+" "+contact.LastName),
                //new Claim(ClaimTypes.Role, roles)
            };

            var token = new JwtSecurityToken(
                issuer: _config.GetSection("JwtSettings:ValidIssuer").Value,
                audience: _config.GetSection("JwtSettings:ValidAudience").Value,
                //issuer: null,
                //audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_config.GetSection("JwtSettings:AccessTokenExpiration").Value)),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }

        
}
