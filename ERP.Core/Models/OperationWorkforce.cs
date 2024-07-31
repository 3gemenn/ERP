using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models
{
    public class OperationWorkforce
    {
        public string Id { get; set; }
        public string OperationId { get; set; }
        public string WorkforceId { get; set; }
        public decimal HoursWorked { get; set; }

        public ProductionOperation ProductionOperation { get; set; }
        public Workforce Workforce { get; set; }
    }
}
