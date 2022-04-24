using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class FizzBuzz
    {
        public int number = GetNumber();
        public string response;

        public static int GetNumber()
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.WriteLine("Podałeś złą wartość. Spróbuj ponownie.");
                    continue;
                }
                return number;
            }
        }
        public string DivisibleNumber()
        {
                if (number % 5 == 0 && number % 3 == 0)
                {
                    response = "FizzBuzz";
                }
                else if (number % 3 == 0)
                {
                    response = "Fizz";
                }
                else if (number % 5 == 0)
                {
                    response = "Buzz";
                }
                else
                {
                    Console.WriteLine(number);
                }
            return response;
        }
    }
}
