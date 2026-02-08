using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_5
{
    // Represents the parking ticket issued to a vehicle
    internal class Ticket
    {
        // Unique ticket number
        private string _ticketNo { get; set; }

        // Time when the vehicle was parked
        private DateTime _parkedTime { get; set; }

        // Parking cost calculated for the vehicle
        private double _cost { get; set; }

        // Parameterized constructor to initialize ticket details
        public Ticket(string _ticketNo, DateTime _parkedTime, double _cost)
        {
            this._ticketNo = _ticketNo;
            this._parkedTime = _parkedTime;
            this._cost = _cost;
        }

        // Getter method used for comparing or searching by parked time
        public DateTime GetParkedTime()
        {
            return this._parkedTime;
        }

        // When ticket object is printed, show ticket number
        public override string ToString()
        {
            return $"{this._ticketNo}";
        }
    }
}
