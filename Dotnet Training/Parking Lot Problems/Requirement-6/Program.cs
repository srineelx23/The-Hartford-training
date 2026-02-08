using System;
using System.Collections.Generic;

namespace Requirement_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Ask user for number of vehicles
                Console.WriteLine("Enter Number Of Vehicles");
                int.TryParse(Console.ReadLine(), out int size);

                // List to store vehicle objects
                List<Vehicle> vehicleList = new List<Vehicle>(size);

                // Read input and create vehicles
                while (size > 0)
                {
                    string input = Console.ReadLine();

                    // Convert string → Vehicle object
                    vehicleList.Add(Vehicle.CreateVehicle(input));

                    size--;
                }

                // Get count of vehicles grouped by type
                // Returned as SortedDictionary so output will be in sorted order of keys
                SortedDictionary<string, int> typeWiseCount = Vehicle.TypeWiseCount(vehicleList);

                // Display header
                Console.Write("{0,-15} {1}\n", "Type", "No. of Vehicles");

                // Print each type and its count
                foreach (var v in typeWiseCount)
                {
                    Console.Write("{0,-15} {1}\n", v.Key, v.Value);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
