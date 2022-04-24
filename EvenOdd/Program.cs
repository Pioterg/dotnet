using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Podaj mi dowolną liczbę całkowitą a ja powiem Ci czy ta liczba jest parzysta czy nieparzysta.");
            Console.ResetColor();
            var selectedNumber = GetNumber();
            var rest = (selectedNumber % 2);
            if (rest == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Podana przez Ciebie liczba jest parzysta.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Podana przez Ciebie liczba jest nieparzysta.");
                Console.ResetColor();
            }
        }
        private static int GetNumber()
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Musisz podać Liczbę. Spróbuj jeszcze raz.");
                    Console.ResetColor();
                    continue;
                }
                return number;
            }
        }
    }
}
