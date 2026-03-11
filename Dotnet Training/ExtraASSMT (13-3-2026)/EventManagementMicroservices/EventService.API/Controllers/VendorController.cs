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
    public class VendorController : ControllerBase
    {
        private readonly VendorService service;

        public VendorController(VendorService service)
        {
            this.service = service;
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateVendorDto dto)
        {
            await service.CreateVendor(dto);

            return Ok("Vendor Created");
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetVendors());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vendor = await service.GetVendorById(id);
            if (vendor == null) return NotFound();
            return Ok(vendor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendor(int id, UpdateVendorDto dto)
        {
            await service.UpdateVendor(id, dto);
            return Ok("Vendor Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            await service.DeleteVendor(id);
            return Ok("Vendor Deleted");
        }
    }
}
