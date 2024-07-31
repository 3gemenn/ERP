using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Dtos
{
    public class WorkforceDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
