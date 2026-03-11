using EventService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Interfaces
{
    public interface IVendorRepository
    {
        Task AddAsync(Vendor vendor);

        Task<List<Vendor>> GetAllAsync();
        Task<Vendor> GetByIdAsync(int id);
        Task UpdateAsync(Vendor vendor);
        Task DeleteAsync(int id);
    }
}
