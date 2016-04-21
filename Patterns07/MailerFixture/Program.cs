using Mailer.Mails;
using Mailer.Parties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailerFixture
{
    class Program
    {
        static void Main(string[] args)
        {
            var recepient = new Party
            {
                Name = "Bart Kemps",
                Address = new Mailer.Geo.Address
                {
                    AddressLines = new[] { "Burgermeester Verderlaan 15" },
                    PostalCode = "3544 AD",
                    City = "Utrecht",
                    Country = "Nederland"
                }
            };

            var sender = new Party
            {
                Name = "Hedgehog Industries",
                Address = new Mailer.Geo.Address
                {
                    AddressLines = new[] { "K.P. van der Mandelelaan 60" },
                    PostalCode = "3062 MB",
                    City = "Rotterdam",
                    Country = "Nederland"
                }
            };

            var subject = "Betalingsachterstand";
            var body = new[]
                 {
                    "Geachte Heer Kemps,",
                    "Onlangs heeft u ons opdracht gegeven een applicatie te bouwen om brieven te genereren. Graag willen wij u erop attenderen dat wij hiervoor tot dusver nog geen betaling hebben ontvangen.",
                    "Zoals u ziet werkt deze applicatie vlekkeloos. Het genereert, precies volgens de specificaties, een brief in HTML-bestandsopmaak. Deze kunt u vanuit uw browser naar de printer sturen.",
                    "Graag ontvangen wij per ommegaande betaling op het bij u bekende bankrekeningnummer.",
                    "Hoogachtend,",
                    "E.E. van Vliet"
                };

            PrintMessage(sender, recepient, subject, body);
        }

        private static void PrintMessage(Party sender, Party recipient, string subject, string[] body)        {
            using (var writer = File.CreateText($"{Guid.NewGuid()}.html"))
            {
                new Letter()
                {
                    Sender = sender,
                    Recipient = recipient,
                    Subject = subject,
                    Body = body,
                    Writer = writer
                }.Print();
            }
        }
    }
}
