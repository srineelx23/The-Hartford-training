namespace Exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Basic Salary: ");
                double basicSalary = Convert.ToDouble(Console.ReadLine());

                double netSalary = SalaryCalculator.SalaryCalculator.CalculateNetSalary(basicSalary);

                Console.WriteLine("\n--- Salary Details ---");
                Console.WriteLine("Employee Name : " + name);
                Console.WriteLine("Basic Salary  : " + basicSalary);
                Console.WriteLine("Net Salary    : " + netSalary);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
