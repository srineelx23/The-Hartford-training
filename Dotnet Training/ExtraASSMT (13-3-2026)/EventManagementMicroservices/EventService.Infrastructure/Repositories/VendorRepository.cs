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
    public class VendorRepository : IVendorRepository
    {
        private readonly EventDbContext context;

        public VendorRepository(EventDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Vendor vendor)
        {
            context.Vendors.Add(vendor);
            await context.SaveChangesAsync();
        }

        public async Task<List<Vendor>> GetAllAsync()
        {
            return await context.Vendors.ToListAsync();
        }

        public async Task<Vendor> GetByIdAsync(int id)
        {
            return await context.Vendors.FindAsync(id);
        }

        public async Task UpdateAsync(Vendor vendor)
        {
            context.Vendors.Update(vendor);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vendor = await context.Vendors.FindAsync(id);
            if (vendor != null)
            {
                context.Vendors.Remove(vendor);
                await context.SaveChangesAsync();
            }
        }
    }
}
