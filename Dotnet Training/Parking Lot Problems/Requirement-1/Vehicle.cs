using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_1
{
    internal class Vehicle
    {
        // Stores vehicle registration number
        private string _registrationNo;

        // Public property to access registration number
        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        // Stores vehicle name
        private string _name;

        // Public property for vehicle name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Stores vehicle type (Two Wheeler / Four Wheeler, etc.)
        private string _type;

        // Public property for vehicle type
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // Stores vehicle weight
        private double _weight;

        // Public property for vehicle weight
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        // Stores ticket details associated with the vehicle
        private Ticket _ticket;

        // Parameterized constructor to initialize vehicle details
        public Vehicle(string _registrationNo, string _name, string _type, double _weight, Ticket _ticket)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
            this._ticket = _ticket;
        }

        // Overrides ToString() to display vehicle details in readable format
        public override string ToString()
        {
            return $"RegistrationNo: {this._registrationNo}\n" +
                   $"Name: {this._name}\n" +
                   $"Type: {this._type}\n" +
                   $"Weight: {this._weight:F1}\n" +   // Displays weight with one decimal
                   $"Ticket No: {this._ticket.ToString()}\n";
        }

        // Overrides Equals() to compare two Vehicle objects
        // Vehicles are considered equal if their registration numbers match (case-insensitive)
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            // Compare registration numbers ignoring case
            if (this.RegistrationNo.ToLower() == ((Vehicle)obj)._registrationNo.ToLower())
            {
                return true;
            }
            return false;
        }

        // Overrides GetHashCode() to maintain consistency with Equals()
        public override int GetHashCode()
        {
            return this.RegistrationNo.GetHashCode();
        }
    }
}
