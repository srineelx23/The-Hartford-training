using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.DTOs
{
    public class UpdateVendorDto
    {
        public string Name { get; set; }
        public string ServiceType { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
