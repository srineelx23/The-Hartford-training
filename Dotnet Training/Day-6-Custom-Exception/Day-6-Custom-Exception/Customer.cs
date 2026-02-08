using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6_Custom_Exception
{
    internal class Customer
    {
        string name;
        int accno,balance;
        public Customer(string name,int accno,int balance)
        {
            this.name = name;
            this.accno = accno;
            this.balance = balance;
        }
        public void withdraw(int amt)
        {
            if (balance - amt <= 100)
                throw new bankexception(accno, balance);
            balance -= amt;
        }
        public int getbalance() { return balance; } 
    }
}
