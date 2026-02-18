using Day_15_Repository_Assignment.Models;
using Day_15_Repository_Assignment.Repository;

namespace Day_15_Repository_Assignment.Services
{
    public interface IPolicyService
    {
        Task<List<Policy>> GetAllPoliciesAsync();
        Task<Policy?> GetPolicyByIdAsync(int id);
        Task CreatePolicyAsync(Policy policy);
        Task<bool> UpdatePolicyAsync(Policy policy);
        Task<bool> DeletePolicyAsync(int id);
    }
}
