using AutoMapper;
using ERP.Core.Dtos;
using ERP.Core.Models;
using ERP.Core.Repositories;
using ERP.Core.Services;
using ERP.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service.Services
{
    public class OperationWorkforceService : Service<OperationWorkforce>,IOperationWorkforceService
    {
        private readonly IGenericRepository<OperationWorkforce> _repository;
        private readonly IGenericRepository<ProductionOperation> _operation;
        private readonly IGenericRepository<Workforce> _workforce;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OperationWorkforceService(IGenericRepository<OperationWorkforce> repository, IGenericRepository<ProductionOperation> operation = null, IGenericRepository<Workforce> workforce = null, IMapper mapper = null, IUnitOfWork unitOfWork = null) : base(repository, unitOfWork)
        {
            _repository = repository;
            _operation = operation;
            _workforce = workforce;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<List<OperationWorkforceDto>>> OperationWorkforces()
        {
            var operationWorkforces = _repository.GetAll().ToList();
            var mapper = _mapper.Map<List<OperationWorkforceDto>>(operationWorkforces);
            return CustomResponseDto<List<OperationWorkforceDto>>.Success(200, mapper);
        }

        public async Task<CustomResponseDto<List<OperationDto>>> SOperation()
        {
            try
            {
                var sOperation = await _operation.GetAll().ToListAsync();

                var mapper = _mapper.Map<List<OperationDto>>(sOperation);

                return CustomResponseDto<List<OperationDto>>.Success(200, mapper);
            }
            catch (Exception ex)
            {
                return CustomResponseDto<List<OperationDto>>.Fail(500, ex.Message);

            }
        }

        public async Task<CustomResponseDto<List<SelectWorkforceDto>>> SWorkforce()
        {
            try
            {
                var sWorkforce = await _workforce.GetAll().ToListAsync();

                var mapper = _mapper.Map<List<SelectWorkforceDto>>(sWorkforce);

                return CustomResponseDto<List<SelectWorkforceDto>>.Success(200, mapper);
            }
            catch (Exception ex)
            {
                return CustomResponseDto<List<SelectWorkforceDto>>.Fail(500, ex.Message);

            }
        }
        public async Task<CustomResponseDto<NoContentDto>> Create(OperationWorkforceDto dto)
        {
            try
            {
                var newDto = _mapper.Map<OperationWorkforce>(dto);
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
    }
}
