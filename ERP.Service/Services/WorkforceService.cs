using AutoMapper;
using ERP.Core.Dtos;
using ERP.Core.Dtos.Account;
using ERP.Core.Models;
using ERP.Core.Repositories;
using ERP.Core.Services;
using ERP.Core.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service.Services
{
    public class WorkforceService : Service<Workforce>, IWorkforceService
    {
        private readonly IGenericRepository<Workforce> _repository;
        private readonly RoleManager<Role> _role;
        private readonly UserManager<User> _user;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public WorkforceService(IGenericRepository<Workforce> repository, IMapper mapper, IUnitOfWork unitOfWork, RoleManager<Role> role, UserManager<User> user) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _role = role;
            _user = user;
        }

        public async Task<CustomResponseDto<List<WorkforceDto>>> Workforces()
        {
            var workforces = _repository.GetAll().ToList();
            var mapper = _mapper.Map<List<WorkforceDto>>(workforces);
            return CustomResponseDto<List<WorkforceDto>>.Success(200, mapper);
        }

        public async Task<CustomResponseDto<List<RoleDto>>> SelectRole()
        {
            try
            {
                var srole = _role.Roles;

                var mapper = _mapper.Map<List<RoleDto>>(srole);

                return CustomResponseDto<List<RoleDto>>.Success(200, mapper);
            }
            catch (Exception ex)
            {
                return CustomResponseDto<List<RoleDto>>.Fail(500, ex.Message);
            }
        }
        public async Task<CustomResponseDto<List<SelectUserDto>>> SelectUser()
        {
            try
            {
                var suser = await _user.Users.ToListAsync();

                var mapper = _mapper.Map<List<SelectUserDto>>(suser);

                return CustomResponseDto<List<SelectUserDto>>.Success(200, mapper);
            }
            catch (Exception ex)
            {
                return CustomResponseDto<List<SelectUserDto>>.Fail(500, ex.Message);
            }
        }

        public async Task<CustomResponseDto<NoContentDto>> Create(WorkforceDto dto)
        {
            try
            {
                var newDto = _mapper.Map<Workforce>(dto);
                newDto.Id = Guid.NewGuid().ToString();

                var add = await _repository.AddAsync(newDto);

                if (add.Success)
                {
                    return CustomResponseDto<NoContentDto>.Success(200);
                }
                else
                {
                    return CustomResponseDto<NoContentDto>.Fail(400, "kayıt edilemedi");
                }
            }
            catch (Exception ex)
            {

                return CustomResponseDto<NoContentDto>.Fail(400, ex.Message);
            }

        }
        public async Task<CustomResponseDto<NoContentDto>> Update(WorkforceDto dto)
        {
            var workforce = _mapper.Map<Workforce>(dto);
            if (workforce == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Product not found");
            }

            var update = await _repository.UpdateAsync(workforce);
            if (update.Success)
            {
                var updatedDto = _mapper.Map<WorkforceDto>(workforce);
                return CustomResponseDto<NoContentDto>.Success(200);
            }
            else
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Güncelleştirme işlemi yapılamadı");
            }

        }

        public async Task<CustomResponseDto<NoContentDto>> Delete(string id)
        {
            var workforce = _repository.Where(x => x.Id == id).FirstOrDefault();
            if (workforce == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Product not found");
            }

            var delete = await _repository.RemoveAsync(workforce);
            if (!delete.Success)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Silme işlemi başarısız oldu");
            }
            return CustomResponseDto<NoContentDto>.Success(200);
        }



    }
}
