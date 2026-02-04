using InsuranceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceLibrary.Services
{
    public class PolicyService
    {
        List<InsurancePolicy> PoliciesList=new List<InsurancePolicy>();
        public void AddPolicy(InsurancePolicy policy)
        {
            PoliciesList.Add(policy);
        }
        public List<InsurancePolicy> GetPoliciesList() {
                return PoliciesList; 
        }
        public InsurancePolicy GetPolicyById(int id) { 
            foreach(var item in PoliciesList)
            {
                if(item.PolicyID == id) return item;
            }
            return null;
        }
        public bool UpdatePolicy(int id,decimal newPremium,int newTerm)
        {
            foreach(var item in PoliciesList)
            {
                if(item.PolicyID == id)
                {
                    item.premiumAmount = newPremium;
                    item.policyTerm = newTerm;
                    return true;
                }
            }
            return false;
        }
        public bool DeletePolicy(int id)
        {
            foreach (var item in PoliciesList)
            {
                if (item.PolicyID == id)
                {

                    PoliciesList.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
