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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service.Services
{
    public class ProductionOperationService : Service<ProductionOperation>, IProductionOperationService
    {
        private readonly IGenericRepository<ProductionOperation> _repository;
        private readonly IGenericRepository<WorkOrder> _workOrderRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductionOperationService(IGenericRepository<ProductionOperation> repository, IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<WorkOrder> workOrderRepository) : base(repository, unitOfWork)
        {
            _workOrderRepository = workOrderRepository;
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<List<ProductionOperationDto>>> ProductionOperations()
        {
            var productionOperations = _repository.GetAll().ToList();
            var mapper = _mapper.Map<List<ProductionOperationDto>>(productionOperations);
            return CustomResponseDto<List<ProductionOperationDto>>.Success(200, mapper);
        }

        public async Task<CustomResponseDto<List<SelectWorkOrderDto>>> SWorkOrder()
        {
            try
            {
                var sWorkOrder = await _workOrderRepository.GetAll().ToListAsync();

                var mapper = _mapper.Map<List<SelectWorkOrderDto>>(sWorkOrder);

                return CustomResponseDto<List<SelectWorkOrderDto>>.Success(200, mapper);
            }
            catch (Exception ex)
            {
                return CustomResponseDto<List<SelectWorkOrderDto>>.Fail(500, ex.Message);

            }
        }

        public async Task<CustomResponseDto<NoContentDto>> Create(ProductionOperationDto dto)
        {
            try
            {
                var newDto = _mapper.Map<ProductionOperation>(dto);
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

        public async Task<CustomResponseDto<NoContentDto>> Update(ProductionOperationDto dto)
        {
            var productionOperation = _mapper.Map<ProductionOperation>(dto);
            if (productionOperation == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Product not found");
            }

            var update = await _repository.UpdateAsync(productionOperation);
            if (update.Success)
            {
                var updatedDto = _mapper.Map<ProductionOperationDto>(productionOperation);
                return CustomResponseDto<NoContentDto>.Success(200);
            }
            else
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Güncelleştirme işlemi yapılamadı");
            }

        }

        public async Task<CustomResponseDto<NoContentDto>> Delete(string id)
        {
            var productionOperation = _repository.Where(x => x.Id == id).FirstOrDefault();
            if (productionOperation == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Product not found");
            }

            var delete = await _repository.RemoveAsync(productionOperation);
            if (!delete.Success)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Silme işlemi başarısız oldu");
            }
            return CustomResponseDto<NoContentDto>.Success(200);
        }
    }
}