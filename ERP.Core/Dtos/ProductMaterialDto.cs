﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Dtos
{
    public class ProductMaterialDto
    {
        public string ProductId { get; set; }
        public List<SelectMaterialDto> Materials{ get; set; }
    }
}
