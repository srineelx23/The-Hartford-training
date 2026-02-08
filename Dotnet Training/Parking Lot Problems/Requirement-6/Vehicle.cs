using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_6
{
    // Represents a vehicle entity
    internal class Vehicle
    {
        // Unique vehicle registration number
        private string _registrationNo;
        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        // Name of the vehicle / owner
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Vehicle category (Car, Bike, etc.)
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // Weight of the vehicle
        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        // Parameterized constructor to initialize vehicle information
        public Vehicle(string _registrationNo, string _name, string _type, double _weight)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
        }

        // Factory method: creates Vehicle object from comma-separated input
        public static Vehicle CreateVehicle(string details)
        {
            // Split input string
            string[] detailsArray = details.Split(',');

            // Extract data
            string registrationNo = detailsArray[0];
            string name = detailsArray[1];
            string type = detailsArray[2];
            double weight = double.Parse(detailsArray[3]);

            // Return vehicle object
            return new Vehicle(registrationNo, name, type, weight);
        }

        // Returns formatted vehicle details for display
        public override string ToString()
        {
            return $"{this.RegistrationNo,-15} {this.Name,-10} {this.Type,-12} {this.Weight,-7:F1}\n";
        }

        // Two vehicles are equal if registration numbers match
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (this.RegistrationNo.ToLower() == ((Vehicle)obj)._registrationNo.ToLower())
            {
                return true;
            }

            return false;
        }

        // Static utility method to count vehicles by their type
        // Returns a SortedDictionary → automatically sorted by key
        public static SortedDictionary<string, int> TypeWiseCount(List<Vehicle> vehicleList)
        {
            SortedDictionary<string, int> typeWiseCount = new SortedDictionary<string, int>();

            // Iterate through each vehicle
            foreach (Vehicle v in vehicleList)
            {
                // If type not present, add with count 1
                if (!typeWiseCount.ContainsKey(v.Type))
                {
                    typeWiseCount.Add(v.Type, 1);
                }
                // If already present, increment count
                else
                {
                    typeWiseCount[v.Type]++;
                }
            }

            return typeWiseCount;
        }
    }
}
