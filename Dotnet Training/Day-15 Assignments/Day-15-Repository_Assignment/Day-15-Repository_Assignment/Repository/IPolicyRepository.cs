using Day_15_Repository_Assignment.Models;

namespace Day_15_Repository_Assignment.Repository
{
    public interface IPolicyRepository
    {
        Task<List<Policy>> GetAllPoliciesAsync();
        Task<Policy?> GetPolicyByIdAsync(int id);
        Task CreatePolicyAsync(Policy policy);
        Task<bool> UpdatePolicyAsync(Policy policy);
        Task<bool> DeletePolicyAsync(int id);
    }
}
