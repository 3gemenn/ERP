﻿using AutoMapper;
using ERP.Core.Dtos;
using ERP.Core.Models;
using ERP.Core.Repositories;
using ERP.Core.Services;
using ERP.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service.Services
{
    public class ProductMaterialService : Service<ProductMaterial>, IProductMaterialService
    {
        private readonly IGenericRepository<ProductMaterial> _repository;
        private readonly IGenericRepository<Product> _pro;
        private readonly IGenericRepository<Material> _mat;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductMaterialService(IGenericRepository<ProductMaterial> repository, IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Product> pro, IGenericRepository<Material> mat ) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _pro = pro;
            _mat = mat;
        }

        public async Task<CustomResponseDto<NoContentDto>> Create(ProductMaterialDto dto)
        {
            try
            {
                List<ProductMaterial> list= new List<ProductMaterial>();
                foreach (var item in dto.Materials)
                {
                    var productMaterial = new ProductMaterial()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProductId = dto.ProductId,
                        MaterialId = item.Id,
                        Quantity = item.Quantity,
                    };
                    list.Add(productMaterial);
                    
                }
                var add = await _repository.AddRangeAsync(list);

                if (add.Success)
                {
                    return CustomResponseDto<NoContentDto>.Success(200);
                }
                else
                {
                    return CustomResponseDto<NoContentDto>.Fail(400,"kayıt edilemedi");
                }
            }
            catch (Exception ex)
            {

                return CustomResponseDto<NoContentDto>.Fail(400, ex.Message);
            }

        }

        public async Task<CustomResponseDto<List<SelectProductDto>>>SProduct()
        {
            try
            {
                var sproducts = await _pro.GetAll().ToListAsync();

                var mapper= _mapper.Map<List<SelectProductDto>>(sproducts);

                return CustomResponseDto<List<SelectProductDto>>.Success(200, mapper);
            }
            catch (Exception ex)
            {
                return CustomResponseDto<List<SelectProductDto>>.Fail(500, ex.Message);
            }
        }

        public async Task<CustomResponseDto<List<SelectMaterialDto>>> SMaterial()
        {
            try
            {
                var smaterial = await _mat.GetAll().ToListAsync();

                var mapper = _mapper.Map<List<SelectMaterialDto>>(smaterial);

                return CustomResponseDto<List<SelectMaterialDto>>.Success(200, mapper);
            }
            catch (Exception ex)
            {
                return CustomResponseDto<List<SelectMaterialDto>>.Fail(500, ex.Message);
            }
        }


    }
}
