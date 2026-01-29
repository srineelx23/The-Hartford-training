namespace Assignment_1_Practice_Programs_for_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p=new Program();
            //sum of first 500 prime numbers
            p.Program1();
            //sum of digits in a number
            p.Program2();
            //check palindrome
            p.Program3();
            //average of 4 numbers
            Program4();
            // convert Celsius to Kelvin and Fahrenheit
            p.Program5();
            // arithmetic operations on two numbers
            p.Program6();
            // remove character from string by index
            p.Program7();
            // arithmetic operations (duplicate logic – optional check)
            p.Program8();
            // convert string to lowercase
            p.Program9();

        }

        public void Program1()
        {
            int sum = 0,c=0,i=1;
            while(c<500)
            {
                if (checkPrime(i))
                {
                    sum = sum + i;
                    c++;
                }
                i++;
            }
            Console.WriteLine(sum);
        }

        public void Program2()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            while (n > 0)
            {
                int dig = n % 10;
                sum +=  dig;
                n = n / 10;
            }
            Console.WriteLine("Sum Of Digits: "+sum);
        }

        public void Program3()
        {
            string str=Console.ReadLine();
            int j = str.Length-1;
            int i = 0;
            while (i < j)
            {
                if (str[i] != str[j])
                {
                    Console.WriteLine("Not Palindrome");
                    return;
                }
                i++;
                j--;
            }
            Console.WriteLine("String is Palindrome");
        }

        public static void Program4()
        {
            Console.WriteLine("Enter number1: ");
            double n1=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter number2: ");
            double n2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter number3: ");
            double n3 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter number4: ");
            double n4 = Convert.ToDouble(Console.ReadLine());

            double avg = (n1 + n2 + n3 + n4) / 4;
            Console.WriteLine(avg);
        }

        public void Program5()
        {
            Console.WriteLine("Enter temperature in Celsius:");
            double celsius = Convert.ToDouble(Console.ReadLine());

            double kelvin = celsius + 273;
            double fahrenheit = (celsius * 9 / 5) + 32;

            Console.WriteLine("Kelvin = " + kelvin);
            Console.WriteLine("Fahrenheit = " + fahrenheit);
        }

        public void Program6()
        {
            Console.WriteLine("Enter first number:");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(a + " + " + b + " = " + (a + b));
            Console.WriteLine(a + " - " + b + " = " + (a - b));
            Console.WriteLine(a + " * " + b + " = " + (a * b));
            Console.WriteLine(a + " / " + b + " = " + (a / b));
            Console.WriteLine(a + " % " + b + " = " + (a % b));
        }
        public void Program7()
        {
            Console.WriteLine("Enter a string:");
            string str = Console.ReadLine();

            Console.WriteLine("Enter index to remove:");
            int index = Convert.ToInt32(Console.ReadLine());

            if (index < 0 || index >= str.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            string result = str.Substring(0, index) + str.Substring(index + 1);
            Console.WriteLine("Result: " + result);
        }
        public void Program8()
        {
            Console.WriteLine("Enter a string:");
            string str = Console.ReadLine();

            bool isNumeric = true;
            bool hasDecimal = false;

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];

                // allow '-' only at first position
                if (ch == '-' && i == 0)
                    continue;

                // allow only one decimal point
                if (ch == '.')
                {
                    if (hasDecimal)
                    {
                        isNumeric = false;
                        break;
                    }
                    hasDecimal = true;
                    continue;
                }

                // digits check
                if (ch < '0' || ch > '9')
                {
                    isNumeric = false;
                    break;
                }
            }

            Console.WriteLine(isNumeric);
        }
        public void Program9()
        {
            Console.WriteLine("Enter a string:");
            string str = Console.ReadLine();

            string result = str.ToLower();
            Console.WriteLine(result);
        }

        public static bool checkPrime(int i)
        {
            if (i == 1) return false;
            if (i == 2) return true;

            for(int j = 2; j * j <= i; j++)
            {
                if (i % j == 0)
                    return false;
            }
            return true;
        }
    }


}
