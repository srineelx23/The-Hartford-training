using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeedingDataAssignment.DTOs;
using SeedingDataAssignment.Models;

namespace SeedingDataAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly ContinentContext _context;

        public StatesController(ContinentContext context)
        {
            _context = context;
        }

        // GET: api/States
        [HttpGet]
        public async Task<ActionResult<List<State>>> GetStates()
        {
            var States= await _context.States.Include(c=>c.Cities).ToListAsync();
            var result=States.Select(s=>new State
            {
                StateId=s.StateId,
                StateName=s.StateName,
                CountryId=s.CountryId,
                Cities =s.Cities.Select(c=>new City
                {
                    CityId=c.CityId,
                    CityName=c.CityName,
                    StateId=c.StateId,
                    //State=c.State
                }).ToList()
            }).ToList();
            return Ok(result);
        }

        // GET: api/States/5
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetState(int id)
        {
            var state = await _context.States.Include(c=>c.Cities).FirstOrDefaultAsync(s=>s.StateId == id);
            if (state == null)
            {
                return NotFound();
            }
            var result = new State
            {
                StateId = state.StateId,
                StateName = state.StateName,
                CountryId= state.CountryId,
                Cities = state.Cities.Select(c => new City
                {
                    CityId = c.CityId,
                    CityName = c.CityName,
                    StateId=c.StateId
                    //State=c.State
                }).ToList()
            };
            return result;

        }

        // PUT: api/States/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(int id, State state)
        {
            if (id != state.StateId)
            {
                return BadRequest();
            }

            _context.Entry(state).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/States
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<State>> PostState(StateDTO state)
        {
            _context.States.Add(new State
            {
                StateName = state.StateName,
                CountryId = state.CountryId
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetState", new { id = state.StateId }, state);
        }

        // DELETE: api/States/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            _context.States.Remove(state);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateExists(int id)
        {
            return _context.States.Any(e => e.StateId == id);
        }
    }
}
