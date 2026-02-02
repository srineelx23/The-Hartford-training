namespace Program_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 2, 9, 1, 7 };

            Console.WriteLine("Original Array:");
            PrintArray(arr);

           
            Array.Sort(arr);
            Console.WriteLine("\nAfter Sort:");
            PrintArray(arr);

           
            Array.Reverse(arr);
            Console.WriteLine("\nAfter Reverse:");
            PrintArray(arr);

            
            int index = Array.IndexOf(arr, 9);
            Console.WriteLine("\nIndex of 9: " + index);

           
            int[] copiedArray = new int[arr.Length];
            Array.Copy(arr, copiedArray, arr.Length);
            Console.WriteLine("\nCopied Array:");
            PrintArray(copiedArray);

            
            Array.Resize(ref arr, 7);
            arr[5] = 10;
            arr[6] = 15;

            Console.WriteLine("\nAfter Resize:");
            PrintArray(arr);

         
            Array.Clear(arr, 1, 2);
            Console.WriteLine("\nAfter Clear (from index 1, length 2):");
            PrintArray(arr);

           
            bool exists = Array.Exists(arr, x => x == 10);
            Console.WriteLine($"\nDoes 10 exist? {exists}");
        }

        static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
