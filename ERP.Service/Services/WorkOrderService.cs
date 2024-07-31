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
    public class WorkOrderService : Service<WorkOrder>, IWorkOrderService
    {
        private readonly IGenericRepository<WorkOrder> _repository;
        private readonly IGenericRepository<Product> _pro;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public WorkOrderService(IGenericRepository<WorkOrder> repository, IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Product> pro) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _pro = pro;
        }

        public async Task<CustomResponseDto<List<WorkOrderDto>>> WorkOrders()
        {
            var workOrders = _repository.GetAll().ToList();
            var mapper = _mapper.Map<List<WorkOrderDto>>(workOrders);
            return CustomResponseDto<List<WorkOrderDto>>.Success(200, mapper);
        }

        public async Task<CustomResponseDto<List<SelectProductDto>>> SProduct()
        {
            try
            {
                var sproducts = await _pro.GetAll().ToListAsync();

                var mapper = _mapper.Map<List<SelectProductDto>>(sproducts);

                return CustomResponseDto<List<SelectProductDto>>.Success(200, mapper);
            }
            catch (Exception ex)
            {
                return CustomResponseDto<List<SelectProductDto>>.Fail(500, ex.Message);
            }
        }

        public async Task<CustomResponseDto<NoContentDto>> Create(WorkOrderDto dto)
        {
            try
            {
                var newDto = _mapper.Map<WorkOrder>(dto);
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
        public async Task<CustomResponseDto<NoContentDto>> Update(WorkOrderDto dto)
        {
            var workOrder = _mapper.Map<WorkOrder>(dto);
            if (workOrder == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Product not found");
            }

            var update = await _repository.UpdateAsync(workOrder);
            if (update.Success)
            {
                var updatedDto = _mapper.Map<WorkOrderDto>(workOrder);
                return CustomResponseDto<NoContentDto>.Success(200);
            }
            else
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Güncelleştirme işlemi yapılamadı");
            }

        }


        public async Task<CustomResponseDto<NoContentDto>> Delete(string id)
        {
            var workOrder = _repository.Where(x => x.Id == id).FirstOrDefault();
            if (workOrder == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Product not found");
            }

            var delete = await _repository.RemoveAsync(workOrder);
            if (!delete.Success)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Silme işlemi başarısız oldu");
            }
            return CustomResponseDto<NoContentDto>.Success(200);
        }

    }
}
