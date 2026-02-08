using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_1
{
    public class Ticket
    {
        // Stores the ticket number
        private string _ticketNo { get; set; }

        // Stores the time when the vehicle was parked
        private DateTime _parkedTime { get; set; }

        // Stores the parking cost
        private double _cost { get; set; }

        // Parameterized constructor to initialize ticket details
        public Ticket(string _ticketNo, DateTime _parkedTime, double _cost)
        {
            this._ticketNo = _ticketNo;
            this._parkedTime = _parkedTime;
            this._cost = _cost;
        }

        // Overrides ToString() to return ticket number
        // This helps in directly printing Ticket object details
        public override string ToString()
        {
            return $"{this._ticketNo}";
        }
    }
}
