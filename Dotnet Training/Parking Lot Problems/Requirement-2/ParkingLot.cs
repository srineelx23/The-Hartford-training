using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2
{
    internal class ParkingLot
    {
        // Name of the parking lot
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // List that stores all parked vehicles
        private List<Vehicle> _vehicleList;

        public List<Vehicle> VehicleList
        {
            get { return _vehicleList; }
            set { _vehicleList = value; }
        }

        // Default constructor
        public ParkingLot()
        {
        }

        // Parameterized constructor
        // Even if list is passed, parking lot starts with an empty list
        public ParkingLot(string _name, List<Vehicle> _vehicleList)
        {
            this.Name = _name;
            this._vehicleList = new List<Vehicle>();
        }

        // Adds a vehicle into the parking lot
        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            this.VehicleList.Add(vehicle);
        }

        // Removes a vehicle based on registration number
        // Returns true if removed, false if not found
        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            foreach (Vehicle v in this.VehicleList)
            {
                if (v.RegistrationNo.Equals(registrationNo))
                {
                    VehicleList.Remove(v);
                    return true;
                }
            }
            return false;
        }

        // Displays all vehicles present in the parking lot
        public void DisplayVehicles()
        {
            // If list is empty
            if (this.VehicleList.Count == 0)
            {
                Console.WriteLine("No vehicles to show");
            }
            else
            {
                // Header
                Console.WriteLine($"Vehicles in {this.Name}");
                Console.Write("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n",
                              "RegistrationNo", "Name", "Type", "Weight", "Ticket No");

                // Print each vehicle
                foreach (Vehicle v in this.VehicleList)
                {
                    Console.WriteLine(v.ToString());
                }
            }
        }
    }
}
