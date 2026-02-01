namespace Exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 'N' Matches: ");
           int n=Convert.ToInt32(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                for(int i = 1; i <= n; i++)
                {
                    Console.Write($"{i*(i-1)*(i+1)} ");
                }
            }
        }
    }
}
