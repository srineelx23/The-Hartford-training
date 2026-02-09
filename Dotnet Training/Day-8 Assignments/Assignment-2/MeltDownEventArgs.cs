using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal class MeltDownEventArgs:EventArgs
    {
        private string message;
        public MeltDownEventArgs(string message)
        {
            this.message = message;
        }

        public string Message
        {
            get { return message; }
        }
    }
}
