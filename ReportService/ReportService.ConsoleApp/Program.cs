using Cipher;
using EmailSender;
using ReportService.Core;
using ReportService.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var stringCipher = new StringCipher("2");
            var encryptedPassword = stringCipher.Encrypt("haslo");
            var decryptedPassword = stringCipher.Decrypt(encryptedPassword);
            Console.WriteLine(encryptedPassword);
            Console.WriteLine(decryptedPassword);


            return;

            var emailReceiver = "rolnik807@gmail.com";
            var htmlEmail = new GenerateHtmlEmail();


            var email = new Email(new EmailParams
            {
                HostSmtp = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                SenderName = "Piotr Sitkowski",
                SenderEmail = "rolnik807@gmail.com",
                SenderEmailPassword = "mmljcsztjibdpckg",
            });

            var report = new Report
            {
                Id = 1,
                Title = "R/1/2023",
                Date = new DateTime(2023, 1, 1, 12, 0, 0),
                Position = new List<ReportPosition>
                {
                    new ReportPosition
                    {
                        Id = 1,
                        ReportId = 1,
                        Title = "Position 1",
                        Description = "Description 1",
                        Value = 43.01M
                    },

                    new ReportPosition
                    {
                        Id = 2,
                        ReportId = 1,
                        Title = "Position 2",
                        Description = "Description 2",
                        Value = 4311M
                    },

                    new ReportPosition
                    {
                        Id = 3,
                        ReportId = 1,
                        Title = "Position 3",
                        Description = "Description 3",
                        Value = 1.99M
                    },
                }
            };

            var errors = new List<Error>
            {
                new Error { Message = "Błąd testowy 1", Date = DateTime.Now },
                new Error { Message = "Błąd testowy 2", Date = DateTime.Now }
            };

            Console.WriteLine("Wysyłaninie e-mail (Raport dobowy)...");

            email.Send("Raport dobowy", htmlEmail.GenerateReport(report), emailReceiver).Wait();

            Console.WriteLine("Wysłano e-mail (Raport dobowy)...");

            Console.WriteLine("Wysyłaninie e-mail (Błędy w naszej aplikacji)...");

            email.Send("Błędy w naszej aplikacji", htmlEmail.GenerateErrors(errors, 10), emailReceiver).Wait();

            Console.WriteLine("Wysłano e-mail (Błędy w naszej aplikacji)...");
        }
    }
}
