using System.Text.RegularExpressions;
namespace Requirement_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Ask user to enter registration number
                Console.WriteLine("Enter the registration no. to be validated");

                // Read input and remove unwanted spaces at start/end
                string input = Console.ReadLine().Trim();

                // Validate registration number
                bool res = ValidateRegistrationNo(input);

                // Display result
                if (res == true)
                {
                    Console.WriteLine("Registration No. is valid");
                }
                else
                {
                    Console.WriteLine("Registration No. is invalid");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        // Method to validate vehicle registration number using regex
        static bool ValidateRegistrationNo(string registrationNo)
        {
            /*
             Pattern Explanation:
             ^                 -> start of string
             [A-Z]{2}          -> state code (2 uppercase letters)
             \s                -> space
             [0-9]{1,2}        -> district number (1 or 2 digits)
             (\s[A-Z]{1,2})?   -> optional series (space + 1 or 2 letters)
             \s                -> space
             [0-9]{1,4}        -> unique number (1 to 4 digits)
             $                 -> end of string
            */
            string pattern = @"^[A-Z]{2}\s[0-9]{1,2}(\s[A-Z]{1,2})?\s[0-9]{1,4}$";

            // Return true if match found, otherwise false
            if (Regex.IsMatch(registrationNo, pattern))
            {
                return true;
            }
            return false;
        }
    }
}
