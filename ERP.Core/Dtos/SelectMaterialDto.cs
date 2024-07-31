using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Dtos
{
    public class SelectMaterialDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
    }
}
