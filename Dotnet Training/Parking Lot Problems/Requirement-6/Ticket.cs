using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_6
{
    // Represents a parking ticket issued to a vehicle
    internal class Ticket
    {
        // Unique ticket identifier
        private string _ticketNo { get; set; }

        // Time when the vehicle entered the parking lot
        private DateTime _parkedTime { get; set; }

        // Parking cost for the vehicle
        private double _cost { get; set; }

        // Parameterized constructor to initialize ticket information
        public Ticket(string _ticketNo, DateTime _parkedTime, double _cost)
        {
            this._ticketNo = _ticketNo;
            this._parkedTime = _parkedTime;
            this._cost = _cost;
        }

        // Returns parked time (used in search/sort operations)
        public DateTime GetParkedTime()
        {
            return this._parkedTime;
        }

        // Defines what should be printed when ticket object is displayed
        public override string ToString()
        {
            return $"{this._ticketNo}";
        }
    }
}
