namespace Program_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer value: ");
            string intInput = Console.ReadLine();

            Console.Write("Enter a decimal value: ");
            string doubleInput = Console.ReadLine();

            if (int.TryParse(intInput, out int intResult))
            {
                Console.WriteLine($"Integer parsed successfully: {intResult}");
            }
            else
            {
                Console.WriteLine("Invalid integer input");
            }

            if (double.TryParse(doubleInput, out double doubleResult))
            {
                Console.WriteLine($"Double parsed successfully: {doubleResult} ");
            }
            else
            {
                Console.WriteLine("Invalid double input");
            }
        }
    }
}
