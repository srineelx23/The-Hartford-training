using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_4
{
    // Business Object class that contains search operations for Vehicle
    internal class VehicleBO
    {
        // Find vehicles based on vehicle type
        // Returns list of vehicles matching the given type
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, string type)
        {
            // List to store matching vehicles
            List<Vehicle> result = new List<Vehicle>();

            // Iterate through all vehicles
            foreach (Vehicle v in vehicleList)
            {
                // Compare type
                if (v.Type.Equals(type))
                {
                    result.Add(v);
                }
            }

            return result;
        }

        // Find vehicles based on parked time
        // Returns list of vehicles parked at the specified time
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            // List to store matching vehicles
            List<Vehicle> result = new List<Vehicle>();

            // Iterate through all vehicles
            foreach (Vehicle v in vehicleList)
            {
                // Compare parked time
                if (v.GetParkedTime().Equals(parkedTime))
                {
                    result.Add(v);
                }
            }

            return result;
        }
    }
}
