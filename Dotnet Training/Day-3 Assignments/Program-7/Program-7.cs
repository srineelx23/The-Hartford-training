namespace Program_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] salaries = { 25000.50, 32000.75, 28000.00 };

            Console.WriteLine("Employee Salary Report\n");

            for (int i = 0; i < salaries.Length; i++)
            {
                ApplyBonus(ref salaries[i]);
                Console.WriteLine(
                    String.Format(
                        "Employee {0}: Salary = {1:F2}",
                        i + 1, salaries[i]
                    )
                );
            }
        }

        static void ApplyBonus(ref double salary)
        {
            salary += salary * 0.10; 
        }
    }
}
