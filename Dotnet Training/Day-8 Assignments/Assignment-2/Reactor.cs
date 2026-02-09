using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal class Reactor
    {
        private int temperature;
        public delegate void MeltDownHandler(object reactor, MeltDownEventArgs myMEA);
        public event MeltDownHandler OnMeltDown;
        public int Temperature
        {
            set
            {
                temperature = value;
                if (temperature > 1000)
                {
                    MeltDownEventArgs myMEA = new MeltDownEventArgs("Reactor Meltdown in progress");
                    OnMeltDown(this, myMEA);
                }
            }
        }
    }
}
