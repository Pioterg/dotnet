using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JednoZdanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj swoje imię: ");
            var firstName = Console.ReadLine();

            Console.Write("Podaj swoje nazwisko: ");
            var lastName = Console.ReadLine();

            Console.Write("Podaj miejsce swojego urodzenia: ");
            var placeOfBirth = Console.ReadLine();

            Console.Write("Podaj rok urodzenia: ");
            var yearOfBirth = int.Parse(Console.ReadLine());

            if (yearOfBirth > DateTime.Today.Year)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Podałęś złą wartość");
                Console.ResetColor();
            }

            Console.Write("Podaj miesiąc urodzenia: ");
            var monthOfBirth = int.Parse(Console.ReadLine());

            if (monthOfBirth > 12 || monthOfBirth < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Podałęś złą wartość");
                Console.ResetColor();
            }

            Console.Write("Podaj dzień urodzenia: ");
            var dayOfBirth = int.Parse(Console.ReadLine());

            if (dayOfBirth > DateTime.DaysInMonth(yearOfBirth, monthOfBirth) || dayOfBirth < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Podałęś złą wartość");
                Console.ResetColor();
            }

            var dateOfBirth = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);

            var age = DateTime.Today.Year - dateOfBirth.Year;

            if (DateTime.Today.DayOfYear < dateOfBirth.DayOfYear)
            {
                age--;
            }

            Information();

            void Information()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Cześć {firstName} {lastName} urodziłeś się w {placeOfBirth} i masz {age} lat.");
                Console.ResetColor();
            }

            Console.ReadKey();
        }
    }
}





    

   
