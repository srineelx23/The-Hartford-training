using EventService.Application.DTOs;
using EventService.Application.Interfaces;
using EventService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Services
{
    public class VendorService
    {
        private readonly IVendorRepository repo;

        public VendorService(IVendorRepository repo)
        {
            this.repo = repo;
        }

        public async Task CreateVendor(CreateVendorDto dto)
        {
            var vendor = new Vendor
            {
                Name = dto.Name,
                ServiceType = dto.ServiceType,
                PaymentAmount = dto.PaymentAmount,
                PaymentCompleted = false
            };

            await repo.AddAsync(vendor);
        }

        public async Task<List<Vendor>> GetVendors()
        {
            return await repo.GetAllAsync();
        }

        public async Task<Vendor> GetVendorById(int id)
        {
            return await repo.GetByIdAsync(id);
        }

        public async Task UpdateVendor(int id, UpdateVendorDto dto)
        {
            var vendor = await repo.GetByIdAsync(id);
            if (vendor != null)
            {
                vendor.Name = dto.Name;
                vendor.ServiceType = dto.ServiceType;
                vendor.PaymentAmount = dto.PaymentAmount;
                await repo.UpdateAsync(vendor);
            }
        }

        public async Task DeleteVendor(int id)
        {
            await repo.DeleteAsync(id);
        }
    }
}
