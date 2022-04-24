using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            var randomNumber = generator.Next(0, 100);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Właśmie wygenerowałem liczbę od 0 do 100, spróbuj ją odgadnąć.");
            Console.ResetColor();
            //Console.WriteLine(randomNumber);
            var numberOfTries = 0;

            while (true)
            {
                numberOfTries++;
                Console.WriteLine("\nPodaj liczbę: ");
                var selectedNumber = GetNumber();
                if (selectedNumber == randomNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Podałeś prawidłową liczbę.");
                    Console.WriteLine($"\nUdało Ci się odgadnąć po {numberOfTries} próbach");
                    Console.ResetColor();
                    break;
                }
                else if (selectedNumber < randomNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPodałeś za małą liczbę.");
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPodałeś za dużą liczbę");
                    Console.ResetColor();
                    continue;
                }   
            }
        }

        private static int GetNumber()
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int number) 
                    || number <= 0 
                    || number >= 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPodałeś złą wartość. Musisz podać liczbę od 0 do 100. Spróbuj ponownie.");
                    Console.ResetColor();
                    continue;
                }
                return number;
            }
        }
    }
}
