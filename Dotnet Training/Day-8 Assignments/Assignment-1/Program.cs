using System;

namespace Assignment_1
{
    // Delegate that points to any method which takes no parameters and returns void
    delegate void Print();

    // Base class representing money
    class Money
    {
        // Protected so derived classes can access
        protected uint Note;
        protected uint Coin;

        // Constructor to initialize note and coin values
        public Money(uint note, uint coin)
        {
            this.Note = note;
            this.Coin = coin;
        }
    }

    // Derived class representing Rupees
    class Rupee : Money
    {
        // Pass values to base constructor
        public Rupee(uint rupees, uint paise) : base(rupees, paise) { }

        // Method to display rupee information
        public void Display()
        {
            Console.WriteLine("Rs. {0}.{1}", Note, Coin);
        }
    }

    // Derived class representing Dollars
    class Dollar : Money
    {
        // Pass values to base constructor
        public Dollar(uint dollar, uint cent) : base(dollar, cent) { }

        // Method to display dollar information
        public void Info()
        {
            Console.WriteLine("${0}.{1}", Note, Coin);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Creating objects
                Rupee m1 = new Rupee(1000, 55);
                Dollar m2 = new Dollar(100, 75);

                // Assign rupee display method to delegate
                Print gp = m1.Display;
                gp();

                // Reassign dollar info method to delegate
                gp = m2.Info;
                gp();
            }
            catch (Exception ex)
            {
                // Handle any runtime error
                Console.WriteLine("Error occurred: " + ex.Message);
            }
        }
    }
}
