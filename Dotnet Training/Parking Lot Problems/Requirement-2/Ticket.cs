using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2
{
    internal class Ticket
    {
        // Ticket number generated for the vehicle
        private string _ticketNo { get; set; }

        // Time at which the vehicle was parked
        private DateTime _parkedTime { get; set; }

        // Parking cost calculated for the vehicle
        private Double _cost { get; set; }

        //Default and Parameterized constructor to initialize ticket details
        public Ticket() { }
        public Ticket(string _ticketNo, DateTime _parkedTime, Double _cost)
        {
            this._ticketNo = _ticketNo;
            this._parkedTime = _parkedTime;
            this._cost = _cost;
        }

        // Returns ticket number when object is printed
        public override string ToString()
        {
            return $"{this._ticketNo}";
        }
    }
}
