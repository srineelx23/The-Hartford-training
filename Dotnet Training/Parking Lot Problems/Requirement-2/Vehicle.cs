using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2
{
    internal class Vehicle
    {
        // Vehicle registration number (unique identifier)
        private string _registrationNo;
        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        // Owner or vehicle name
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Vehicle type (Car/Bike/Truck etc.)
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // Weight of the vehicle
        private Double _weight;
        public Double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        // Ticket associated with the vehicle
        private Ticket _ticket;

        //Default and Parameterized constructor to initialize all vehicle details
        public Vehicle() { }
        public Vehicle(string _registrationNo, string _name, string _type, Double _weight, Ticket _ticket)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
            this._ticket = _ticket;
        }

        // Factory method to create Vehicle object from comma separated input
        public static Vehicle CreateVehicle(string details)
        {
            // Split input string
            string[] detailsArray = details.Split(',');

            // Extract values
            string registrationNo = detailsArray[0];
            string name = detailsArray[1];
            string type = detailsArray[2];
            Double weight = double.Parse(detailsArray[3]);

            // Parse ticket details
            DateTime parkedTime = DateTime.ParseExact(detailsArray[5], "dd-MM-yyyy HH:mm:ss", null);
            double cost = Convert.ToDouble(detailsArray[6]);

            // Create ticket object
            Ticket ticket = new Ticket(detailsArray[4], parkedTime, cost);

            // Return fully constructed vehicle
            return new Vehicle(registrationNo, name, type, weight, ticket);
        }

        // Returns formatted vehicle information for display
        public override string ToString()
        {
            return $"{this.RegistrationNo,-15} {this.Name,-10} {this.Type,-12} {this.Weight,-7:F1} {this._ticket.ToString()}\n";
        }

        // Two vehicles are equal if their registration numbers are same
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
    }
}
