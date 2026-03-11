using EventService.Application.DTOs;
using EventService.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventService.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly GuestService service;

        public GuestController(GuestService service)
        {
            this.service = service;
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateGuestDto dto)
        {
            await service.CreateGuest(dto);

            return Ok("Guest Added");
        }

        [HttpPut("{id}/rsvp")]

        public async Task<IActionResult> UpdateRsvp(int id, UpdateRsvpDto dto)
        {
            await service.UpdateRsvp(id, dto);

            return Ok("RSVP Updated");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllGuests());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var guest = await service.GetGuestById(id);
            if (guest == null) return NotFound();
            return Ok(guest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuest(int id, UpdateGuestDto dto)
        {
            await service.UpdateGuest(id, dto);
            return Ok("Guest Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await service.DeleteGuest(id);
            return Ok("Guest Deleted");
        }
    }
}
