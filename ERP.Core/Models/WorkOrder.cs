using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models
{
    public class WorkOrder
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }

        public Product Product { get; set; }
        public ICollection<ProductionOperation> ProductionOperations { get; set; }
    }
}
