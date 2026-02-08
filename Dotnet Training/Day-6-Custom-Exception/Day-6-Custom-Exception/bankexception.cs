using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6_Custom_Exception
{
    internal class bankexception:Exception
    {
        int acc;
        int bal;
        public bankexception(int acc,int bal)
        {
            this.acc = acc;
            this.bal = bal;
        }   
        public void inform()
        {
            Console.WriteLine($"Account number: {acc} Balance left: {bal}");
        }
    }
}
