using InsuranceLibrary.Models;
using InsuranceLibrary.Services;
using System.Collections.Generic;
namespace InsuranceConsoleApp
{
    internal class Program
    {
        static PolicyService policyService = new PolicyService();
        //int id = 101;
        static void Main(string[] args)
        {
            
            int option;
            int id = 101;
            do
            {
                Console.WriteLine("Welcome To Insurance Management System. Please Select One of the Options From Below");
                Console.WriteLine("1. Add Policy\n2. View All Policies\n3. Search Policy By Id\n4. Update Policy\n5. Delete Policy\n0. Exit");
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 0:break;
                    case 1:AddPolicy(id++);break;
                    case 2:ViewPolicies();break;
                    case 3:GetPolicyById();break; 
                    case 4:UpdatePolicy();break;
                    case 5:DeletePolicy();break;
                    default:Console.WriteLine("Enter Valid Option");break;
                }

            }
            while (option != 0);
        }

        static void AddPolicy(int id)
        {
            //PolicyService policyService=new PolicyService();
            InsurancePolicy newPolicy=new InsurancePolicy();
            Console.Write("Enter Policy Holder Name: ");
            string policyName = Console.ReadLine();
            newPolicy.policyHolderName = policyName;
            newPolicy.PolicyID = id;
            Console.WriteLine();
            Console.Write("Enter Policy Type\n1. Health\n2. Life\n3. Vehicle\n");
            int.TryParse(Console.ReadLine(), out int PolicyOption);
            if (PolicyOption == 1)
            {
                newPolicy.policyType = "Health";
            }
            else if (PolicyOption == 2) {
                newPolicy.policyType = "Life";
            }
            else if (PolicyOption == 3)
            {
                newPolicy.policyType = "Vehicle";
            }
            else
            {
                Console.WriteLine("Enter Valid Option");
                return;
            }
            Console.Write("Enter Policy Premium Amount: ");
            decimal.TryParse(Console.ReadLine(), out decimal premiumAmount);
            newPolicy.premiumAmount = premiumAmount;
            Console.Write("Enter Policy Term: ");
            int.TryParse(Console.ReadLine(), out int policyTerm);
            newPolicy.policyTerm = policyTerm;
            Console.WriteLine("Enter Status: \n1. True\n2. False");
            int.TryParse(Console.ReadLine(), out int statusOpt);
            if (statusOpt == 1)
            {
                newPolicy.isActive = true;
            }
            else if (statusOpt == 2) { newPolicy.isActive = false; }
            else
            {
                Console.WriteLine("Enter Valid Option");
            }
            //Console.WriteLine(newPolicy.PolicyID+" "+newPolicy.policyHolderName+" "+newPolicy.policyType+" "+newPolicy.premiumAmount+" "+newPolicy.policyTerm+" "+newPolicy.isActive);
            policyService.AddPolicy(newPolicy);
        }
        static void ViewPolicies()
        {
            List<InsurancePolicy> policiesList = policyService.GetPoliciesList();

            if (policiesList.Count == 0)
            {
                Console.WriteLine("Policies List Empty");
                return;
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                $"{"ID",-5} {"Holder Name",-20} {"Type",-10} {"Premium",-12} {"Term (Years)",-12} {"Active",-8}");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (var p in policiesList)
            {
                Console.WriteLine(
                    $"{p.PolicyID,-5} {p.policyHolderName,-20} {p.policyType,-10} {p.premiumAmount,-12:C} {p.policyTerm,-12} {p.isActive,-8}");
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------");
        }
        static void UpdatePolicy()
        {
            Console.Write("Enter POlicy Id: ");
            int.TryParse(Console.ReadLine(), out int selectedId);
            //Console.WriteLine();
            Console.Write("Enter New Premium Amount: ");
            decimal.TryParse(Console.ReadLine(), out decimal newPremiumAmount);
            Console.Write("Enter New Premium Term: ");
            int.TryParse(Console.ReadLine(), out int newPremiumTerm);
            bool res=policyService.UpdatePolicy(selectedId, newPremiumAmount,newPremiumTerm);
            if (res == true)
            {
                Console.WriteLine("Policy Updated Successfully");
            }
            else if (res == false)
            {
                Console.WriteLine("Policy Not Found. Enter Valid PolicyId");
            }
        }

        static void GetPolicyById()
        {
            Console.Write("Enter Policy Id: ");
            int.TryParse(Console.ReadLine(), out int selectedId);
            InsurancePolicy selectedPolicy= policyService.GetPolicyById(selectedId);
            if (selectedPolicy == null) {
                Console.WriteLine("Enter Valid Policy ID");
            }
            else
            {
                string res=selectedPolicy.ToString();
                Console.WriteLine(res);
            }
        }

        static void DeletePolicy()
        {
            Console.Write("Enter Policy Id: ");
            int.TryParse(Console.ReadLine(),out int selectedId);
            bool res=policyService.DeletePolicy(selectedId);
            if (res == true)
            {
                Console.WriteLine($"Policy {selectedId} has been deleted");
            }
            else if (res == false)
            {
                Console.WriteLine("Enter Valid Policy ID");
            }
        }
    }
}
