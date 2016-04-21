using Mailer.Mails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailerFixture
{
    class Program
    {
        static void Main(string[] args)
        {
            var recepient = new[]
            {
                "Bart Kemps",
                "Burgermeester Verderlaan 15",
                "3544 AD  UTRECHT"
            };

            var sender = new[]
            {
                "Hedgehog Industries",
                "K.P. van der Mandelelaan 60",
                "3062 MB  ROTTERDAM",
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

        private static void PrintMessage(string[] sender, string[] recipient, string subject, string[] body)        {
            Letter.Print(sender, recipient, subject, body);
        }
    }
}
