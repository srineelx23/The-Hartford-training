using System;
using System.Collections.Generic;

namespace Requirement_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Ask how many vehicles will be entered
                Console.WriteLine("Enter Number Of Vehicles");
                int.TryParse(Console.ReadLine(), out int size);

                // Create list to store vehicles
                List<Vehicle> vehicleList = new List<Vehicle>(size);

                // Read vehicle details and build objects
                while (size > 0)
                {
                    string input = Console.ReadLine();

                    // Convert string → Vehicle
                    vehicleList.Add(Vehicle.CreateVehicle(input));

                    size--;
                }

                // Ask user how to sort
                Console.WriteLine("Enter a type to sort:\n1. Sort by weight\n2. Sort by parked time");
                int.TryParse(Console.ReadLine(), out int option);

                // Option 1 → default sorting (IComparable implemented in Vehicle)
                if (option == 1)
                {
                    vehicleList.Sort();

                    // Display header
                    Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n",
                                      "RegistrationNo", "Name", "Type", "Weight", "Ticket No");

                    // Display sorted list
                    foreach (Vehicle v in vehicleList)
                    {
                        Console.WriteLine(v.ToString());
                    }
                }

                // Option 2 → custom sorting using IComparer
                else if (option == 2)
                {
                    vehicleList.Sort(new parkedTimeComparer());

                    // Display header
                    Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n",
                                      "RegistrationNo", "Name", "Type", "Weight", "Ticket No");

                    // Display sorted list
                    foreach (Vehicle v in vehicleList)
                    {
                        Console.WriteLine(v.ToString());
                    }
                }

                // Invalid menu choice
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
