using ERP.Core.Dtos.Account;
using ERP.Core.Dtos;
using ERP.Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models;
using AutoMapper;
using ERP.Core.Repositories;
using ERP.Core.UnitOfWorks;
using ERP.Repository.UnitOfWorks;

namespace ERP.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;   
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<List<ProductDto>>> Products()
        {
            var products = _repository.GetAll().ToList();
            var mapper = _mapper.Map<List<ProductDto>>(products);
            return CustomResponseDto<List<ProductDto>>.Success(200, mapper);
        }

        public async Task<CustomResponseDto<NoContentDto>> Create(ProductDto dto)
        {
            var newDto = _mapper.Map<Product>(dto);
            newDto.Id = Guid.NewGuid().ToString();
            //var pro = new Product
            //{
            //    Name = dto.Name,
            //    Description = dto.Description,
            //    UnitePrice = dto.UnitePrice,
            //    CreatedDate = dto.CreatedDate,
            //};
            //var product = _mapper.Map<Product>(dto);
            var add = await _repository.AddAsync(newDto);
            if (!add.Success)
            {
                return CustomResponseDto<NoContentDto>.Fail(400,"Ürün eklenemedi");
            }
            return CustomResponseDto<NoContentDto>.Success(200);

        }
        public async Task<CustomResponseDto<NoContentDto>> Update(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            if (product == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Product not found");
            }

            var update = await _repository.UpdateAsync(product);
            if (update.Success)
            {
                var updatedDto = _mapper.Map<ProductDto>(product);
                return CustomResponseDto<NoContentDto>.Success(200);
            }
            else
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Güncelleştirme işlemi yapılamadı");
            }
            
        }


        public async Task<CustomResponseDto<NoContentDto>> Delete(string id)
        {
            var product = _repository.Where(x => x.Id == id).FirstOrDefault();
            if (product == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Product not found");
            }

            var delete = await _repository.RemoveAsync(product);
            if (!delete.Success)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Silme işlemi başarısız oldu");
            }
            return CustomResponseDto<NoContentDto>.Success(200);
        }
    }
}
