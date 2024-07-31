using AutoMapper;
using ERP.Core.Dtos;
using ERP.Core.Dtos.Account;
using ERP.Core.Models;
using ERP.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ERP.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        //private readonly SignInManager<User> _signInManager;
        //private readonly IEmailSender _emailSender;
        // private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            // _signInManager = _signInManager;
            //_emailSender = _emailSender;
        }

        public async Task<CustomResponseDto<UserGetDto>> GetById(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                var mapper = _mapper.Map<UserGetDto>(user);
                return CustomResponseDto<UserGetDto>.Success(200, mapper);
            }
            catch (Exception e)
            {
                return CustomResponseDto<UserGetDto>.Fail(400, e.Message);
            }
        }

        public async Task<CustomResponseDto<NoContentDto>> Login(LoginParameterDto dto)
        {
            // gelen email dbde var mı?
            //varsa

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Invalid login attempt.");
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (passwordCheck)
            {
                // Add additional logic here if needed, like generating a JWT token
                return CustomResponseDto<NoContentDto>.Success(200);
            }
            else
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Invalid login attempt.");
            }
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<NoContentDto>> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponseDto<NoContentDto>> Register(RegisterParameterDto dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                UserName = dto.FirstName + dto.LastName,
            };
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                return CustomResponseDto<NoContentDto>.Success(200);
            }

            else
            {
                var error = "";
                foreach (var item in result.Errors)
                {
                    error += item.Description + " ";
                }
                return CustomResponseDto<NoContentDto>.Fail(400, error);
            };
        }

        public async Task<CustomResponseDto<List<UserGetDto>>> Users()
        {
            try
            {
                var users = _userManager.Users.ToList();
                var mapper = _mapper.Map<List<UserGetDto>>(users);
                return CustomResponseDto<List<UserGetDto>>.Success(200, mapper);
            }
            catch (Exception ex)
            {
                // Handle exceptions accordingly
                return CustomResponseDto<List<UserGetDto>>.Fail(500, ex.Message);
            }

        }

        public async Task<CustomResponseDto<UserGetDto>> Update(UserGetDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id);
            if (user == null)
            {
                return CustomResponseDto<UserGetDto>.Fail(404, "User not found.");
            }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return CustomResponseDto<UserGetDto>.Success(200);
            }
            else
            {
                var error = "";
                foreach (var item in result.Errors)
                {
                    error += item.Description + " ";
                }
                return CustomResponseDto<UserGetDto>.Fail(400, error);
            }
        }

        // Delete User
        public async Task<CustomResponseDto<UserGetDto>> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return CustomResponseDto<UserGetDto>.Fail(404, "User not found.");
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return CustomResponseDto<UserGetDto>.Success(200);
            }
            else
            {
                var error = "";
                foreach (var item in result.Errors)
                {
                    error += item.Description + " ";
                }
                return CustomResponseDto<UserGetDto>.Fail(400, error);
            }
        }

    }
}
