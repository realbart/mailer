using Mailer.Geo;
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
                Address = new Address(RegionCollection.Current["NL-UT"], "Burgermeester Verderlaan 15")
                {
                    PostalCode = "3544 AD",
                    City = "Utrecht",
                }
            };

            var sender = new Party
            {
                Name = "Hedgehog Industries",
                Address = new Address(RegionCollection.Current["NL-ZH"], "K.P. van der Mandelelaan 60")
                {
                    PostalCode = "3062 MB",
                    City = "Rotterdam",
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

            var subjectPromotional = "Je hebt gewonnen!";
            var bodyPromotional = new[]
            {
                    "Geachte Heer Kemps,",
                    "Jij hebt meegedaan aan de prijsvraag van deze maand en gewonnen!",
                    "Op vertoon van deze brief mag jij samen met je ouders en een vriendje of vriendinnetje komen kijken hoe wij hier bij Hedgehog Industries ons werk doen.",
                    "Ook hebben we een leuke verrassiong voor je!",
                    "Hoogachtend,",
                    "E.E. van Vliet"
                };

            PrintMessage(sender, recepient, subject, body);
            PrintPromotionalMessage(sender, recepient, subjectPromotional, bodyPromotional);
        }

        private static void PrintMessage(Party sender, Party recipient, string subject, string[] body)
        {
            using (var letter = new LetterFactory().CreateMessage("default"))
            {
                letter.Sender = sender;
                letter.Recipient = recipient;
                letter.Subject = subject;
                letter.Body = body;
                letter.Send();
            }
        }

        private static void PrintPromotionalMessage(Party sender, Party recipient, string subject, string[] body)
        {
            using (var letter = new LetterFactory().CreateMessage("promotional"))
            {
                letter.Sender = sender;
                letter.Recipient = recipient;
                letter.Subject = subject;
                letter.Body = body;
                letter.Send();
            }
        }
    }
}
