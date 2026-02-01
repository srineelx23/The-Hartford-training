namespace Exercise_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.Write("Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Email ID: ");
            string email = Console.ReadLine();

            Console.Write("Type of Connection (Industrial/Business/Domestic/Agricultural): ");
            string connectionType = Console.ReadLine();

            Console.Write("Previous Reading: ");
            double prevReading = double.Parse(Console.ReadLine());

            Console.Write("Current Reading: ");
            double currReading = double.Parse(Console.ReadLine());

            double unitsConsumed = currReading - prevReading;
            double energyCharge = CalculateEnergyCharge(unitsConsumed);
            double meterRent = CalculateMeterRent(connectionType);

            double totalAmount = energyCharge + meterRent;

            PrintBill(customerId, name, address, phone, email,
                      connectionType, unitsConsumed,
                      energyCharge, meterRent, totalAmount);
        }

        static double CalculateEnergyCharge(double units)
        {
            double amount = 0;

            if (units <= 100)
                amount = units * 1.5;
            else if (units <= 250)
                amount = (100 * 1.5) + ((units - 100) * 2.5);
            else if (units <= 550)
                amount = (100 * 1.5) + (150 * 2.5) + ((units - 250) * 4.5);
            else
                amount = (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + ((units - 550) * 7.5);

            return amount;
        }

        static double CalculateMeterRent(string type)
        {
            switch (type.ToLower())
            {
                case "industrial": return 2500;
                case "business": return 1500;
                case "domestic": return 1000;
                case "agricultural": return 0;
                default: return 0;
            }
        }

        static void PrintBill(int id, string name, string address,
                              string phone, string email, string type,
                              double units, double energyCharge,
                              double meterRent, double total)
        {
            Console.WriteLine("\n+------------------------------------------------------+");
            Console.WriteLine("|                 ELECTRICITY BILL                     |");
            Console.WriteLine("+------------------------------------------------------+");
            Console.WriteLine($"| Customer ID      : {id,-34} |");
            Console.WriteLine($"| Name             : {name,-35} |");
            Console.WriteLine($"| Address          : {address,-35} |");
            Console.WriteLine($"| Phone            : {phone,-35} |");
            Console.WriteLine($"| Email            : {email,-35} |");
            Console.WriteLine($"| Connection Type  : {type,-35} |");
            Console.WriteLine("+------------------------------------------------------+");
            Console.WriteLine($"| Units Consumed   : {units,-35}|");
            Console.WriteLine($"| Energy Charge    : ₹{energyCharge,-34:F2}|");
            Console.WriteLine($"| Meter Rent       : ₹{meterRent,-34:F2}|");
            Console.WriteLine("+------------------------------------------------------+");
            Console.WriteLine($"| Total Amount     : ₹{total,-34:F2} |");
            Console.WriteLine("+------------------------------------------------------+");
        }
    }
}
