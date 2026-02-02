namespace Program_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of rows: ");
            int.TryParse(Console.ReadLine(), out int n);
            int[][] ja = new int[n][];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter number of columns for {i}th row");
                int.TryParse(Console.ReadLine(), out int k);
                ja[i] = new int[k];
                for (int j = 0; j < k; j++)
                {
                    int.TryParse(Console.ReadLine(), out ja[i][j]);
                }
            }
            foreach (int[] row in ja)
            {
                foreach (int i in row)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }
        }
    }
}
