using ERP.Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service.Validations
{
    public class MaterialValidator : AbstractValidator<MaterialDto>
    {
        public MaterialValidator()
        {
            RuleFor(material => material.Id).NotEmpty().WithMessage("Material Id cannot be empty.");
            RuleFor(material => material.Name).MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");
            RuleFor(material => material.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters.");
            RuleFor(product => product.UnitPrice).InclusiveBetween(0.01M, 10000M).WithMessage("UnitPrice must be between 0.01 and 10000.");
        }

    }
}
