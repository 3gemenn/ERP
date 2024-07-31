using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitePrice { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<WorkOrder> WorkOrders { get; set; }
        public ICollection<ProductMaterial> ProductMaterials { get; set; }
    }
}
