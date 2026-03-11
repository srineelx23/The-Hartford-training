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
    public class GuestService
    {
        private readonly IGuestRepository repo;

        public GuestService(IGuestRepository repo)
        {
            this.repo = repo;
        }

        public async Task CreateGuest(CreateGuestDto dto)
        {
            var guest = new Guest
            {
                Name = dto.Name,
                Email = dto.Email,
                RSVPStatus = "Pending"
            };

            await repo.AddAsync(guest);
        }

        public async Task UpdateRsvp(int id, UpdateRsvpDto dto)
        {
            var guest = await repo.GetByIdAsync(id);
            if (guest != null)
            {
                guest.RSVPStatus = dto.Status;
                await repo.UpdateAsync(guest);
            }
        }

        public async Task<List<Guest>> GetAllGuests()
        {
            return await repo.GetAllAsync();
        }

        public async Task<Guest> GetGuestById(int id)
        {
            return await repo.GetByIdAsync(id);
        }

        public async Task UpdateGuest(int id, UpdateGuestDto dto)
        {
            var guest = await repo.GetByIdAsync(id);
            if (guest != null)
            {
                guest.Name = dto.Name;
                guest.Email = dto.Email;
                await repo.UpdateAsync(guest);
            }
        }

        public async Task DeleteGuest(int id)
        {
            await repo.DeleteAsync(id);
        }
    }
}
