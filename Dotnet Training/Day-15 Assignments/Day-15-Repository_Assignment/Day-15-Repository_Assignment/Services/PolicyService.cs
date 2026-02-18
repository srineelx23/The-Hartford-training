using Day_15_Repository_Assignment.Models;
using Day_15_Repository_Assignment.Repository;

namespace Day_15_Repository_Assignment.Services
{
    public class PolicyService:IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;
        public PolicyService(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }
        public Task<List<Policy>> GetAllPoliciesAsync()
        {
            return _policyRepository.GetAllPoliciesAsync();
        }
        public Task<Policy?> GetPolicyByIdAsync(int id)
        {
            return _policyRepository.GetPolicyByIdAsync(id);
        }
        public Task CreatePolicyAsync(Policy policy)
        {
            return _policyRepository.CreatePolicyAsync(policy);
        }
        public Task<bool> UpdatePolicyAsync(Policy policy)
        {
            return _policyRepository.UpdatePolicyAsync(policy);
        }
        public Task<bool> DeletePolicyAsync(int id)
        {
            return _policyRepository.DeletePolicyAsync(id);
        }
    }
}
