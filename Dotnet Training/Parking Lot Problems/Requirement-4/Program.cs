using System.Xml.Linq;
using System.Collections.Generic;

namespace Requirement_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Ask user for number of vehicles to input
                Console.WriteLine("Enter Number Of Vehicles");
                int.TryParse(Console.ReadLine(), out int size);

                // Create list to store vehicles
                List<Vehicle> vehicleList = new List<Vehicle>(size);

                // Read vehicle details and create objects
                while (size > 0)
                {
                    string input = Console.ReadLine();

                    // Convert input string → Vehicle object
                    vehicleList.Add(Vehicle.CreateVehicle(input));

                    size--;
                }

                // Business Object used for search operations
                VehicleBO vehicleBo = new VehicleBO();

                // Ask how user wants to search
                Console.WriteLine("Enter a search type:\n1. By type\n2. By parked time");
                int.TryParse(Console.ReadLine(), out int option);

                // Search by vehicle type
                if (option == 1)
                {
                    Console.WriteLine("Enter search type:");

                    List<Vehicle> searchResult = vehicleBo.FindVehicle(vehicleList, Console.ReadLine());

                    // If no vehicles found
                    if (searchResult.Count == 0)
                    {
                        Console.WriteLine("No such vehicle is present");
                        return;
                    }

                    // Display header
                    Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n",
                                      "RegistrationNo", "Name", "Type", "Weight", "Ticket No");

                    // Display each vehicle
                    foreach (Vehicle v in searchResult)
                    {
                        Console.WriteLine(v.ToString());
                    }
                }

                // Search by parked time
                else if (option == 2)
                {
                    Console.WriteLine("Enter the parked time:");

                    DateTime.TryParse(Console.ReadLine(), out DateTime parkedTime);

                    List<Vehicle> searchResult = vehicleBo.FindVehicle(vehicleList, parkedTime);

                    // If no vehicles found
                    if (searchResult.Count == 0)
                    {
                        Console.WriteLine("No such vehicle is present");
                        return;
                    }

                    // Display header
                    Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n",
                                      "RegistrationNo", "Name", "Type", "Weight", "Ticket No");

                    // Display each vehicle
                    foreach (Vehicle v in searchResult)
                    {
                        Console.WriteLine(v.ToString());
                    }
                }

                // Invalid option
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
