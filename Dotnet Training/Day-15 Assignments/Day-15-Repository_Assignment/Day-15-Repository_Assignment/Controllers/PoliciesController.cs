using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day_15_Repository_Assignment.Models;
using Day_15_Repository_Assignment.Services;

namespace Day_15_Repository_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _service;

        public PoliciesController(IPolicyService service)
        {
            _service = service;
        }

        // GET: api/Policies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicies()
        {
            return await _service.GetAllPoliciesAsync();
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            var policy = await _service.GetPolicyByIdAsync(id);

            if (policy == null)
            {
                return NotFound();
            }

            return policy;
        }

        // PUT: api/Policies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicy(int id, Policy policy)
        {
            if (id != policy.PolicyId)
            {
                return BadRequest();
            }

            //_context.Entry(policy).State = EntityState.Modified;

            //try
            //{
                var res=await _service.UpdatePolicyAsync(policy);
            if(res==false)
            {
                return NotFound();
            }
            return Ok("Policy Updated Successfully");
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //if (!PolicyExists(id))
            //{
            //return NotFound();
                //}
                //else
                //{
                    //throw;
                //}
            //}

            //return NoContent();
        }

        // POST: api/Policies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(Policy policy)
        {
            await _service.CreatePolicyAsync(policy);

            return CreatedAtAction("GetPolicy", new { id = policy.PolicyId }, policy);
        }

        // DELETE: api/Policies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        { 
           var res=await _service.DeletePolicyAsync(id);
            if(res==false)
            {
                return NotFound();
            }
            return Ok("Policy Deleted Successfully");
        }

        //private bool PolicyExists(int id)
        //{
        //    return _context.Policies.Any(e => e.PolicyId == id);
        //}
    }
}
