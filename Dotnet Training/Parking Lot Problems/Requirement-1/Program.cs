using System;
using System.Collections.Generic;

namespace Requirement_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // -------- Vehicle 1 Input --------
                Console.WriteLine("Enter Vehicle 1 Details:");

                // Read input line and split values using comma
                string[] input = Console.ReadLine().Split(',');

                // Assign values to variables
                string registrationNo = input[0];
                string name = input[1];
                string type = input[2];

                // Convert string to double for weight
                double weight = Convert.ToDouble(input[3]);

                // Ticket details
                string ticketNo = input[4];

                // Parse date and time in given format
                DateTime parkedTime = DateTime.ParseExact(input[5], "dd-MM-yyyy HH:mm:ss", null);

                // Convert string to double for cost
                double cost = Convert.ToDouble(input[6]);

                // Create Ticket object
                Ticket ticket1 = new Ticket(ticketNo, parkedTime, cost);

                // Create Vehicle object using ticket
                Vehicle vehicle1 = new Vehicle(registrationNo, name, type, weight, ticket1);

                // -------- Vehicle 2 Input --------
                Console.WriteLine("Enter Vehicle 2 Details:");

                // Read second vehicle details
                input = Console.ReadLine().Split(',');

                registrationNo = input[0];
                name = input[1];
                type = input[2];
                weight = Convert.ToDouble(input[3]);
                ticketNo = input[4];

                parkedTime = DateTime.ParseExact(input[5], "dd-MM-yyyy HH:mm:ss", null);

                cost = Convert.ToDouble(input[6]);

                // Create Ticket object for vehicle 2
                ticket1 = new Ticket(ticketNo, parkedTime, cost);

                // Create Vehicle object for vehicle 2
                Vehicle vehicle2 = new Vehicle(registrationNo, name, type, weight, ticket1);

                // -------- Display Vehicle Details --------
                Console.WriteLine("\nVehicle 1 Details\n");
                Console.WriteLine(vehicle1.ToString());

                Console.WriteLine("\nVehicle 2 Details\n");
                Console.WriteLine(vehicle2.ToString());

                // -------- Compare Vehicles --------
                bool res = vehicle1.Equals(vehicle2);

                if (res == true)
                {
                    Console.WriteLine("Vehicle 1 is same as Vehicle 2");
                }
                else
                {
                    Console.WriteLine("Vehicle 1 and Vehicle 2 are different");
                }
            }
            catch (Exception e)
            {
                // Handles any runtime errors (format, null, index, etc.)
                Console.WriteLine(e.Message);
            }
        }
    }
}
