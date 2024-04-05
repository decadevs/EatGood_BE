using EatGood_Domain.DTOs;
using EatGood_Domain.ResponseSystem;

namespace Eat_Good_Services.Interfaces
{
    public interface IAuthenticationServices
    {
        Task<Result<RegisterResponseDto>> RegisterAsync(AppUserCreateDto appUserCreateDto);
        Task<Result<LoginResponseDto>> LoginAsync(AppUserLoginDto loginDTO);
    }
}
