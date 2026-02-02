namespace Program_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = 8.5678;
            int count = 5;
            string name = "Srineel";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

           
            Console.WriteLine(String.Format("F0 (no decimals): {0:F0}", num));
            Console.WriteLine(String.Format("F1 (1 decimal): {0:F1}", num));
            Console.WriteLine(String.Format("F2 (2 decimals): {0:F2}", num));

            
            Console.WriteLine(String.Format("Currency: {0:C}", num));

            
            Console.WriteLine(String.Format("Number format: {0:N2}", 1234567.89));

        
            Console.WriteLine(String.Format("Percentage: {0:P2}", 0.856));

          
            Console.WriteLine(String.Format("Left aligned : |{0,-10}|", name));
            Console.WriteLine(String.Format("Right aligned: |{0,10}|", name));

            
            Console.WriteLine(String.Format(
                "Name: {0}, Count: {1:D3}, Value: {2:F2}",
                name, count, num));
        }
    }
}
