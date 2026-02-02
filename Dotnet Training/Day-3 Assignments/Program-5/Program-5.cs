namespace Program_5
{
    internal class Program
    {

        static void ValueType(int x)
        {
            x = 100;
        }

        static void RefType(ref int x)
        {
            x = 200;
        }

        static void OutType(int a, int b, out int sum)
        {
            sum = a + b;
        }

        static int ParamsType(params int[] numbers)
        {
            int total = 0;
            foreach (int n in numbers)
            {
                total += n;
            }
            return total;
        }
        static void Main(string[] args)
        {
            int num = 10;

            ValueType(num);
            Console.WriteLine($"After ValueType: {num}");

            RefType(ref num);
            Console.WriteLine($"After RefType: {num}");

            OutType(5, 3, out int result);
            Console.WriteLine($"Sum using out: {result}");

            int sum = ParamsType(1, 2, 3, 4, 5);
            Console.WriteLine($"Sum using params: {sum}");
        }
    }
}
