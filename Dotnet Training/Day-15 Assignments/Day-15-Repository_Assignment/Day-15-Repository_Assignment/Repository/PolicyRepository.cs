using Day_15_Repository_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_15_Repository_Assignment.Repository
{
    public class PolicyRepository:IPolicyRepository
    {
        private readonly InsuranceContext _context;
        public PolicyRepository(InsuranceContext context) {
            _context = context;
        }
        public async Task<List<Policy>> GetAllPoliciesAsync()
        {
            return await _context.Policies.ToListAsync();
        }
        public async Task<Policy?> GetPolicyByIdAsync(int id)
        {
            return await _context.Policies
                        .FirstOrDefaultAsync(p => p.PolicyId == id);
        }
        public async Task CreatePolicyAsync(Policy policy)
        {
            await _context.Policies.AddAsync(policy);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeletePolicyAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null) return false; 
            await _context.Policies.Where(p=>p.PolicyId==id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePolicyAsync(Policy policy)
        {
            var Findpolicy = await _context.Policies.FindAsync(policy.PolicyId);
            if (Findpolicy == null) return false;
           Findpolicy.PolicyName = policy.PolicyName;
            Findpolicy.PolicyTerm=policy.PolicyTerm;
            Findpolicy.CustomerId=policy.CustomerId;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
