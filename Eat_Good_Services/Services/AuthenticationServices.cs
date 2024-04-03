using Eat_Good_Data.Repositories.Generic.Interface;
using Eat_Good_Services.Interfaces.Services;
using EatGood_Domain.DTOs;
using EatGood_Domain.Entities;
using EatGood_Domain.ResponseSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eat_Good_Services.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AuthenticationServices> _logger;

        public AuthenticationServices(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, ILogger<AuthenticationServices> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _logger = logger;
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
                    //await _userManager.AddToRoleAsync(appUser, "User");
                    //token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);



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
                else
                {
                    return new Result<RegisterResponseDto> { IsSuccess = false, ErrorMessage = "User with this phone number already exists.", Content = null, StatusCode = StatusCodes.Status400BadRequest };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a manager " + ex.InnerException);
                return new Result<RegisterResponseDto> { IsSuccess = false, ErrorMessage = "Error occured while creating user", Content = null, StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
