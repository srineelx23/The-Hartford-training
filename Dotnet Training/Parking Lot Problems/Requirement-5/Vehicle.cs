using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_5
{
    // Represents a vehicle parked in the parking lot
    // Implements IComparable for default sorting behaviour
    internal class Vehicle : IComparable<Vehicle>
    {
        // Unique registration number of the vehicle
        private string _registrationNo;
        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        // Vehicle / owner name
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Type of vehicle (Car, Bike, etc.)
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

        // Ticket issued to this vehicle
        private Ticket _ticket;

        // Parameterized constructor to initialize vehicle data
        public Vehicle(string _registrationNo, string _name, string _type, double _weight, Ticket _ticket)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
            this._ticket = _ticket;
        }

        // Factory method to create Vehicle object from comma-separated input
        public static Vehicle CreateVehicle(string details)
        {
            // Split input
            string[] detailsArray = details.Split(',');

            // Extract vehicle info
            string registrationNo = detailsArray[0];
            string name = detailsArray[1];
            string type = detailsArray[2];
            double weight = double.Parse(detailsArray[3]);

            // Extract ticket info
            DateTime parkedTime = DateTime.ParseExact(detailsArray[5], "dd-MM-yyyy HH:mm:ss", null);
            double cost = Convert.ToDouble(detailsArray[6]);

            // Create ticket
            Ticket ticket = new Ticket(detailsArray[4], parkedTime, cost);

            // Return vehicle
            return new Vehicle(registrationNo, name, type, weight, ticket);
        }

        // Provides formatted output for table display
        public override string ToString()
        {
            return $"{this.RegistrationNo,-15} {this.Name,-10} {this.Type,-12} {this.Weight,-7:F1} {this._ticket.ToString()}\n";
        }

        // Exposes parked time via ticket (delegation)
        public DateTime GetParkedTime()
        {
            return this._ticket.GetParkedTime();
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

        // Default comparison → sort vehicles by weight
        // Called when List.Sort() is used without comparer
        public int CompareTo(Vehicle? other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
}
