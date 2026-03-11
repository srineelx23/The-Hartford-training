using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.DTOs
{
    public class VendorResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ServiceType { get; set; }

        public bool PaymentCompleted { get; set; }
    }
}
