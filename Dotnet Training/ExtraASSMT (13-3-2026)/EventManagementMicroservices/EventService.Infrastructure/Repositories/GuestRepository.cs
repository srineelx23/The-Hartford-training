using EventService.Application.Interfaces;
using EventService.Domain.Entities;
using EventService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Infrastructure.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly EventDbContext context;

        public GuestRepository(EventDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Guest guest)
        {
            context.Guests.Add(guest);
            await context.SaveChangesAsync();
        }

        public async Task<Guest> GetByIdAsync(int id)
        {
            return await context.Guests.FindAsync(id);
        }

        public async Task UpdateAsync(Guest guest)
        {
            context.Guests.Update(guest);
            await context.SaveChangesAsync();
        }

        public async Task<List<Guest>> GetAllAsync()
        {
            return await context.Guests.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var guest = await context.Guests.FindAsync(id);
            if (guest != null)
            {
                context.Guests.Remove(guest);
                await context.SaveChangesAsync();
            }
        }
    }
}
