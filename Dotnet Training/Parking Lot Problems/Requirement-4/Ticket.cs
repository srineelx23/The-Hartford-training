using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_4
{
    // Represents parking ticket details for a vehicle
    public class Ticket
    {
        // Unique ticket number
        private string _ticketNo { get; set; }

        // Time at which the vehicle was parked
        private DateTime _parkedTime { get; set; }

        // Parking cost for the vehicle
        private Double _cost { get; set; }

        // Parameterized constructor to initialize ticket information
        public Ticket(string _ticketNo, DateTime _parkedTime, Double _cost)
        {
            this._ticketNo = _ticketNo;
            this._parkedTime = _parkedTime;
            this._cost = _cost;
        }

        // Returns the parked time (used for searching/filtering)
        public DateTime GetParkedTime()
        {
            return this._parkedTime;
        }

        // When printed, ticket number is shown
        public override string ToString()
        {
            return $"{this._ticketNo}";
        }
    }
}
