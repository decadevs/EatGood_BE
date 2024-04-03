using Eat_Good_Data.Repositories.Generic.Interface;
using EatGood_Domain.DTOs;
using EatGood_Domain.Entities;
using EatGood_Domain.ResponseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eat_Good_Services.Interfaces.Services
{
    public interface IAuthenticationServices
    {
        Task<Result<RegisterResponseDto>> RegisterAsync(AppUserCreateDto appUserCreateDto);
    }
}
