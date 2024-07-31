using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models
{
    public class ProductionOperation
    {
        public string Id { get; set; }
        public string WorkOrderId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }

        public WorkOrder WorkOrder { get; set; }
        public ICollection<OperationWorkforce> OperationWorkforces { get; set; }
    }
}
