namespace Program_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] marks = new int[5];

            Console.WriteLine("Enter 5 student marks:");

            for (int i = 0; i < marks.Length; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out marks[i]))
                {
                    Console.WriteLine("Invalid input. Enter integer marks:");
                }
            }

            DisplayStats(marks);
        }

        static void DisplayStats(int[] arr)
        {
            Array.Sort(arr);

            int min = arr[0];
            int max = arr[arr.Length - 1];

            int sum = 0;
            foreach (int m in arr)
                sum += m;

            double avg = (double)sum / arr.Length;

            Console.WriteLine("\nMinimum Marks: " + min);
            Console.WriteLine("Maximum Marks: " + max);
            Console.WriteLine("Average Marks: " + avg);
        }
    }
}
