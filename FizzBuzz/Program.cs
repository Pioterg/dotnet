using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbę całkowitą podzielną przez 3 lub 5 a ja Ci coś powiem: ");
            FizzBuzz selectedNumber = new FizzBuzz();
            var c  = selectedNumber.DivisibleNumber();
            Console.WriteLine(c);
        }
    }
}
