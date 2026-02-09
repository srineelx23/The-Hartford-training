using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal class ReactorMonitor
    {
        public ReactorMonitor(Reactor r)
        {
            r.OnMeltDown += new Reactor.MeltDownHandler(DisplayMessage);
        }

        public void DisplayMessage(object reactor, MeltDownEventArgs myMEA)
        {
            Console.WriteLine(myMEA.Message);
        }
    }
}
