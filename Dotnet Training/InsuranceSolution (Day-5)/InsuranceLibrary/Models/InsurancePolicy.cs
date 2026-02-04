using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceLibrary.Models
{
    public class InsurancePolicy
    {
        private int PolicyId;

        public int PolicyID
        {
            get { return PolicyId; }
            set { PolicyId = value; }
        }
        private string PolicyHolderName;

        public string policyHolderName
        {
            get { return PolicyHolderName; }
            set { PolicyHolderName = value; }
        }
        private string PolicyType;

        public string policyType
        {
            get { return PolicyType; }
            set
            {
                if (value == "Health" || value == "Life" || value == "Vehicle")
                {
                    PolicyType = value;
                }
                else
                {
                    throw new ApplicationException("Invalid POlicyType");
                }
            }
        }
        private decimal PremiumAmount;

        public decimal premiumAmount
        {
            get { return PremiumAmount; }
            set { PremiumAmount = value; }
        }

        private int PolicyTerm;

        public int policyTerm
        {
            get { return PolicyTerm; }
            set { PolicyTerm = value; }
        }

        private bool IsActive;

        public bool isActive
        {
            get { return IsActive; }
            set { IsActive = value; }
        }

        public InsurancePolicy()
        {
            //int policyId,string policyHoldername,string policyType,decimal premiumAmount,int policyTerm,bool isactive)
            //PolicyID = policyId;
            //PolicyHolderName = policyHoldername;
            //this.PolicyType = policyType;
            //PremiumAmount = premiumAmount;
            //PolicyTerm = policyTerm;
            //IsActive = isactive;
        }
        public override string ToString()
        {
            return $"{PolicyID} | {policyHolderName} | {policyType} | {premiumAmount}";
        }
    }
}
