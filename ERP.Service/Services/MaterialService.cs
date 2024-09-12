using AutoMapper;
using ERP.Core.Dtos;
using ERP.Core.Models;
using ERP.Core.Repositories;
using ERP.Core.Services;
using ERP.Core.UnitOfWorks;
using ERP.Repository.UnitOfWorks;
using ERP.Service.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service.Services
{
    public class MaterialService : Service<Material>, IMaterialService
    {
        private readonly IGenericRepository<Material> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MaterialService(IGenericRepository<Material> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<List<MaterialDto>>> Materials()
        {
            var materials = _repository.GetAll().ToList();
            var mapper = _mapper.Map<List<MaterialDto>>(materials);
            return CustomResponseDto<List<MaterialDto>>.Success(200, mapper);
        }

        public async Task<CustomResponseDto<NoContentDto>> Create(MaterialDto dto)
        {
            var validator = new MaterialValidator();
            var validationResult = validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return CustomResponseDto<NoContentDto>.Fail(400, errorMessages);
            }

            var newDto = _mapper.Map<Material>(dto);
            newDto.Id = Guid.NewGuid().ToString();
           
            var add = await _repository.AddAsync(newDto);
            if (!add.Success)
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Material eklenemedi");
            }
            return CustomResponseDto<NoContentDto>.Success(200);

        }
        public async Task<CustomResponseDto<NoContentDto>> Update(MaterialDto dto)
        {
            var validator = new MaterialValidator();
            var validationResult = validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return CustomResponseDto<NoContentDto>.Fail(400, errorMessages);
            }
            var material = _mapper.Map<Material>(dto);
            if (material == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Product not found");
            }

            var update = await _repository.UpdateAsync(material);
            if (update.Success)
            {
                var updatedDto = _mapper.Map<MaterialDto>(material);
                return CustomResponseDto<NoContentDto>.Success(200);
            }
            else
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Güncelleştirme işlemi yapılamadı");
            }

        }

        public async Task<CustomResponseDto<NoContentDto>> Delete(string id)
        {
            var material = _repository.Where(x => x.Id == id).FirstOrDefault();
            if (material == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Material not found");
            }

            var delete = await _repository.RemoveAsync(material);
            if (!delete.Success)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Silme işlemi başarısız oldu");
            }
            return CustomResponseDto<NoContentDto>.Success(200);
        }
    }
}
