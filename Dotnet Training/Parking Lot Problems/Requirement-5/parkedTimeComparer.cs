using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_5
{
    // Custom comparer class used to sort vehicles by parked time
    internal class parkedTimeComparer : IComparer<Vehicle>
    {
        // Compare method decides ordering between two vehicles
        public int Compare(Vehicle? x, Vehicle? y)
        {
            // Delegates comparison to parked time available via Ticket
            // Earlier parked vehicle will come first (ascending order)
            return x.GetParkedTime().CompareTo(y.GetParkedTime());
        }
    }
}
