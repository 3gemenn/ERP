using ERP.Core.Dtos;
using ERP.Core.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Services
{
    public interface IUserService
    {
        Task<CustomResponseDto<NoContentDto>> Login(LoginParameterDto dto);
        Task<CustomResponseDto<NoContentDto>> Logout();
        Task<CustomResponseDto<NoContentDto>> Register(RegisterParameterDto dto);
        Task<CustomResponseDto<List<UserGetDto>>> Users();
        Task<CustomResponseDto<UserGetDto>> GetById(string id);
        Task<CustomResponseDto<UserGetDto>> Update(UserGetDto dto);
        Task<CustomResponseDto<UserGetDto>> Delete(string id);

    }
}
