using EventService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Interfaces
{
    public interface IGuestRepository
    {
        Task AddAsync(Guest guest);

        Task<Guest> GetByIdAsync(int id);

        Task UpdateAsync(Guest guest);

        Task<List<Guest>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
