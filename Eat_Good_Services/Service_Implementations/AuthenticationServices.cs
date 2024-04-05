using Azure;
using Eat_Good_Data.Repositories.Generic.Interface;
using Eat_Good_Services.Interfaces;
using EatGood_Domain.DTOs;
using EatGood_Domain.Entities;
using EatGood_Domain.ResponseSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Eat_Good_Services.Service_Implementations
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IRepository<AppUser> _repository;
        private readonly IConfiguration _config;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppSettings _appSettings;

        public AuthenticationServices(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IRepository<AppUser> repository, IConfiguration config, IOptions<AppSettings> appSettings, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;
            _config = config;
            _roleManager = roleManager;
            _appSettings = appSettings.Value;
        }


        public async Task<Result<RegisterResponseDto>> RegisterAsync(AppUserCreateDto appUserCreateDto)
        {
            try
            {
                // Check if a user with the provided email already exists
                var existingUserByEmail = await _userManager.FindByEmailAsync(appUserCreateDto.Email);
                if (existingUserByEmail != null)
                {
                    return new Result<RegisterResponseDto>()
                    {
                        Content = null,
                        Message = "User with this email already exists.",
                        IsSuccess = false
                    };


                }

                // Check if a user with the provided phone number already exists
                var existingUserByPhone = await _repository.GetFirstOrDefaultAsync(x => x.PhoneNumber == appUserCreateDto.PhoneNumber);
                if (existingUserByPhone != null)
                {
                    return new Result<RegisterResponseDto>()
                    {
                        Content = null,
                        Message = "User with this phone number already exists.",
                        IsSuccess = false
                    };


                }

                // Create a new user object
                var appUser = new AppUser
                {
                    FirstName = appUserCreateDto.FirstName,
                    LastName = appUserCreateDto.LastName,
                    Email = appUserCreateDto.Email,
                    PhoneNumber = appUserCreateDto.PhoneNumber,
                    UserName = appUserCreateDto.Email
                };



                // Attempt to create the user
                var result = await _userManager.CreateAsync(appUser, appUserCreateDto.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(appUserCreateDto.Role))
                    {
                        // If not, create it
                        var role = new IdentityRole(appUserCreateDto.Role);
                        await _roleManager.CreateAsync(role);
                    }
                    // Add the user to the "USER" role
                    var addToRoleResult = await _userManager.AddToRoleAsync(appUser, appUserCreateDto.Role);

                    if (!addToRoleResult.Succeeded)
                    {
                        return new Result<RegisterResponseDto>()
                        {
                            Content = null,
                            Message = "Failed to add user to role.",
                            IsSuccess = false
                        };
                    }


                    var response = new RegisterResponseDto
                    {
                        Id = appUser.Id,
                        Email = appUser.Email,
                        PhoneNumber = appUser.PhoneNumber,
                        FirstName = appUser.FirstName,
                        LastName = appUser.LastName,

                    };


                    // Return success message
                    return new Result<RegisterResponseDto>()
                    {
                        Content = response,
                        Message = "User registered successfully. Please click on the link sent to your email to confirm your account.",
                        IsSuccess = true
                    };
                }
                else
                {
                    // Handle failure cases, e.g., password requirements not met, database errors, etc.
                    // You may also include more detailed error messages from 'result.Errors' if needed
                    return new Result<RegisterResponseDto>()

                    {
                        Content = null,
                        Message = "User registration failed. Please try again.",
                        IsSuccess = false
                    };

                }
            }
            catch (Exception ex)
            {
                // Log the exception and return a failure result
                // Log.Error(ex, "An error occurred during user registration.");
                return new Result<RegisterResponseDto>()
                {
                    Content = null,
                    Message = "An error occurred during user registration. Please try again later.",
                    IsSuccess = false
                };
            }
        }



        //public async Task<Result<RegisterResponseDto>> RegisterAsync(AppUserCreateDto appUserCreateDto)
        //{
        //    try
        //    {
        //        // Check if a user with the provided email already exists
        //        var existingUserByEmail = await _userManager.FindByEmailAsync(appUserCreateDto.Email);
        //        if (existingUserByEmail != null)
        //        {
        //            return new Result<RegisterResponseDto>()
        //            {
        //                Content = null,
        //                Message = "User with this email already exists.",
        //                IsSuccess = false
        //            };
        //        }

        //        // Check if a user with the provided phone number already exists
        //        var existingUserByPhone = await _repository.GetFirstOrDefaultAsync(x => x.PhoneNumber == appUserCreateDto.PhoneNumber);
        //        if (existingUserByPhone != null)
        //        {
        //            return new Result<RegisterResponseDto>()
        //            {
        //                Content = null,
        //                Message = "User with this phone number already exists.",
        //                IsSuccess = false
        //            };
        //        }

        //        // Create a new user object
        //        var appUser = new AppUser
        //        {
        //            FirstName = appUserCreateDto.FirstName,
        //            LastName = appUserCreateDto.LastName,
        //            Email = appUserCreateDto.Email,
        //            PhoneNumber = appUserCreateDto.PhoneNumber,
        //            UserName = appUserCreateDto.Email
        //        };

        //        // Attempt to create the user
        //        var result = await _userManager.CreateAsync(appUser, appUserCreateDto.Password);
        //        if (result.Succeeded)
        //        {
        //            // Add user to role
        //            var addToRoleResult = await AddUserToRoleAsync(appUser, appUserCreateDto.Role);
        //            if (!addToRoleResult.IsSuccess)
        //            {
        //                return new Result<RegisterResponseDto>()
        //                {
        //                    Content = null,
        //                    Message = "Failed to add user to role.",
        //                    IsSuccess = false
        //                };
        //            }

        //            var response = new RegisterResponseDto
        //            {
        //                Id = appUser.Id,
        //                Email = appUser.Email,
        //                PhoneNumber = appUser.PhoneNumber,
        //                FirstName = appUser.FirstName,
        //                LastName = appUser.LastName
        //            };

        //            // Return success message
        //            return new Result<RegisterResponseDto>()
        //            {
        //                Content = response,
        //                Message = "User registered successfully. Please click on the link sent to your email to confirm your account.",
        //                IsSuccess = true
        //            };
        //        }
        //        else
        //        {
        //            // Handle failure cases
        //            return new Result<RegisterResponseDto>()
        //            {
        //                Content = null,
        //                Message = "User registration failed. Please try again.",
        //                IsSuccess = false
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception and return a failure result
        //        // Log.Error(ex, "An error occurred during user registration.");
        //        return new Result<RegisterResponseDto>()
        //        {
        //            Content = null,
        //            Message = "An error occurred during user registration. Please try again later.",
        //            IsSuccess = false
        //        };
        //    }
        //}


        //private async Task<Result<object>> AddUserToRoleAsync(AppUser user, string roleName)
        //{
        //    try
        //    {
        //        // Check if the role exists
        //        if (!await _roleManager.RoleExistsAsync(roleName))
        //        {
        //            // If not, create it
        //            var role = new IdentityRole(roleName);
        //            var roleCreationResult = await _roleManager.CreateAsync(role);
        //            if (!roleCreationResult.Succeeded)
        //            {
        //                return new Result<object>() { IsSuccess = false, ErrorMessage = "Failed to create role." };
        //            }
        //        }

        //        // Add the user to the role
        //        var addToRoleResult = await _userManager.AddToRoleAsync(user, roleName);
        //        if (addToRoleResult.Succeeded)
        //        {
        //            return new Result<object>() { IsSuccess = true };
        //        }
        //        else
        //        {
        //            return new Result<object>() { IsSuccess = false, ErrorMessage = "Failed to add user to role." };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception and return a failure result
        //        return new Result<object>() { IsSuccess = false, ErrorMessage = $"An error occurred: {ex.Message}" };
        //    }
        //}






        public async Task<Result<LoginResponseDto>> LoginAsync(AppUserLoginDto loginDTO)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);
                if (user == null)
                {
                    return new Result<LoginResponseDto>()
                    {
                        Content = null,
                        Message = "User not found",
                        IsSuccess = false
                    };
                }
                if (!user.EmailConfirmed)
                {
                    return new Result<LoginResponseDto>()
                    {
                        Content = null,
                        Message = "Email not confirmed.",
                        IsSuccess = false,
                    };
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, lockoutOnFailure: false);

                switch (result)
                {
                    case { Succeeded: true }:
                        var role = (await _userManager.GetRolesAsync(user)).First();
                        user.LastLogin = DateTime.Now;
                        await _repository.UpdateAsync(user);

                        var response = new LoginResponseDto
                        {
                            JWToken = GenerateJwtToken(user, role)
                        };

                        return new Result<LoginResponseDto>()
                        {
                            Content = response,
                            Message = "Login was Successful",
                            IsSuccess = true,
                            RequestTime = DateTime.Now,
                            ResponseTime = DateTime.Now,
                        };

                    case { IsLockedOut: true }:
                        return new Result<LoginResponseDto>()
                        {
                            Content = null,
                            Message = "Account is locked out. Please try again later or contact support." +
                            $" You can unlock your account after {_userManager.Options.Lockout.DefaultLockoutTimeSpan.TotalMinutes} minutes.",
                            IsSuccess = false,
                        };

                    case { RequiresTwoFactor: true }:
                        return new Result<LoginResponseDto>()
                        {
                            Content = null,
                            Message = "Two-factor authentication is required.",
                            IsSuccess = false,
                        };

                    case { IsNotAllowed: true }:
                        return new Result<LoginResponseDto>()
                        {
                            Content = null,
                            Message = "Login failed. Email confirmation is required.",
                            IsSuccess = false,
                            RequestTime = DateTime.Now,
                        };

                    default:
                        return new Result<LoginResponseDto>()
                        {
                            Content = null,
                            Message = "Login failed. Invalid email or password.",
                            IsSuccess = false,
                        };

                }
            }
            catch (Exception ex)
            {
                return new Result<LoginResponseDto>()
                {
                    Content = null,
                    Message = "Some error occurred while login in." + ex.Message,
                    IsSuccess = false,
                };
            }
        }

        //private string GenerateJwtToken(AppUser contact, string roles)
        //{
        //    var jwtSettings = _config.GetSection("JwtSettings:Secret").Value;
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings));
        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //            new Claim(JwtRegisteredClaimNames.Sub, contact.Id),
        //            new Claim(JwtRegisteredClaimNames.Email, contact.Email),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //            new Claim(JwtRegisteredClaimNames.GivenName, contact.FirstName+" "+contact.LastName),
        //            new Claim(ClaimTypes.Role, roles)
        //        };

        //    var token = new JwtSecurityToken(
        //        //issuer: _config.GetValue<string>("JwtSettings:ValidIssuer"),
        //        //audience: _config.GetValue<string>("JwtSettings:ValidAudience"),
        //        issuer: null,
        //        audience: null,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(int.Parse(_config.GetSection("JwtSettings:AccessTokenExpiration").Value)),
        //        signingCredentials: credentials
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}




        public string GenerateJwtToken(AppUser user, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            // Create a list to store the claims
            var claims = new List<Claim>
            {
             // Add the user's ID as a claim
                 new Claim("id", user.Id.ToString())
            };

            // Add additional claims as needed
            if (!string.IsNullOrEmpty(user.Email))
            {
                claims.Add(new Claim(ClaimTypes.Email, user.Email));
            }

              claims.Add(new Claim(ClaimTypes.Role, role));
            // Add other claims such as unique identifier, name, and roles here

            // Create the claims identity
            var claimsIdentity = new ClaimsIdentity(claims);

            // Create the token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Create and write the JWT token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }






    }


}
