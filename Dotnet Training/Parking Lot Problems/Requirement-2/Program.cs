using System.Xml.Linq;
using System.Collections.Generic;

namespace Requirement_2
{
    internal class Program
    {
        // Single parking lot instance used throughout the application
        static ParkingLot parkingLot;

        static void Main(string[] args)
        {
            try
            {
                // Welcome message
                Console.WriteLine("Welcome to the parking lot management system!");

                // Read parking lot name from user
                Console.WriteLine("Enter the name of the parking lot:");
                string parkingLotName = Console.ReadLine();

                // Create parking lot object with empty vehicle list
                parkingLot = new ParkingLot(parkingLotName, new List<Vehicle>());

                int option;

                // Menu loop runs until user selects Exit
                do
                {
                    Console.WriteLine("1. Add a vehicle\n2. Delete Vehicles\n3. Display Vehicles\n4. Exit\nEnter Your Choice:");

                    // Read user choice
                    int.TryParse(Console.ReadLine(), out option);

                    switch (option)
                    {
                        case 1:
                            AddVehicle();
                            break;

                        case 2:
                            DeleteVehicle();
                            break;

                        case 3:
                            DisplayVehicles();
                            break;

                        case 4:
                            // exit handled by loop condition
                            break;

                        default:
                            Console.WriteLine("Invalid option! Please try again.");
                            break;
                    }

                } while (option != 4);
            }
            catch (Exception e)
            {
                // Global exception handling
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        // Method to add a vehicle into parking lot
        static void AddVehicle()
        {
            // Read vehicle details in required format
            string details = Console.ReadLine();

            // Convert input string → Vehicle object
            Vehicle newVehicle = Vehicle.CreateVehicle(details);

            // Add vehicle to parking lot
            parkingLot.AddVehicleToParkingLot(newVehicle);

            Console.WriteLine("vehicle successfully added");
        }

        // Method to display all vehicles
        static void DisplayVehicles()
        {
            parkingLot.DisplayVehicles();
        }

        // Method to delete vehicle by registration number
        static void DeleteVehicle()
        {
            Console.WriteLine("Enter the registration number of the vehicle to be deleted:\r");

            string registrationNo = Console.ReadLine();

            // Try removing vehicle
            bool res = parkingLot.RemoveVehicleFromParkingLot(registrationNo);

            if (res == true)
            {
                Console.WriteLine("Vehicle successfully deleted");
            }
            else
            {
                Console.WriteLine("Vehicle not found in parking lot");
            }
        }
    }
}
