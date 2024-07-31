using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models
{
    public class ProductMaterial
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string MaterialId { get; set; }
        public decimal Quantity { get; set; }

        public Product Product { get; set; }
        public Material Material { get; set; }
    }
}
