namespace SalaryCalculator
{
    public class SalaryCalculator 
    {
        public static double CalculateNetSalary(double basicSalary)
        {
            try
            {
                if (basicSalary <= 0)
                {
                    throw new ArgumentException("Basic salary must be greater than zero.");
                }

                double hra = 0.20 * basicSalary;
                double da = 0.10 * basicSalary;
                double pf = 0;

                if (basicSalary >= 15000)
                {
                    pf = 0.12 * basicSalary;
                }

                double netSalary = basicSalary + hra + da - pf;
                return netSalary;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while calculating salary: " + ex.Message);
            }
        }
    }
}
