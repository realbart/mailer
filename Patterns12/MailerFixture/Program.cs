using Mailer.Geo;
using Mailer.Mails;
using Mailer.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesFixture
{
    class Program
    {
        private static LetterFactory letterFactory = new LetterFactory();

        static void Main(string[] args)
        {
            var sender = new SendingParty
            {
                Name = "Hedgehog Industries",
                EMail = "hedgehog@kemps.eu",
                Closing = new[] { "Met vriendelijke groet,", "Erik van Vliet", "directeur" },
                PhoneNumber = "+31 10 4146171",
                FaxNumber = "+31 10 2136858",
                Address = new Address(RegionCollection.Current["NL-ZH"], "K.P. van der Mandelelaan 60") { PostalCode = "3062 MB", City = "Rotterdam" }
            };

            var receipient = new ReceivingParty
            {
                Name = "Bart Kemps",
                EMail = "b.kemps@betabit.nl",
                Salutation = "Beste Bart,",
                PhoneNumber = "+31 30 3033619",
                FaxNumber = "+31 40 7470158",
                Address = new Address(RegionCollection.Current["NL-UT"], "Burgermeester Verderlaan 15") { PostalCode = "3544 AD", City = "Utrecht" }
            };

            PrintDefault(sender, receipient);
            PrintPromotional(sender, receipient);
        }

        private static void PrintDefault(Party sender, Party receipient)
        {
            using (var msg = letterFactory.CreateMessage("default"))
            {
                msg.Sender = sender;
                msg.Recipient = receipient;
                msg.Subject = "Betalingsachterstand";
                msg.Body = new[]
                    {
                        "Onlangs heeft u ons opdracht gegeven een applicatie te bouwen om brieven te genereren. Graag willen wij u erop attenderen dat wij hiervoor tot dusver nog geen betaling hebben ontvangen.",
                        "Zoals u ziet werkt deze applicatie vlekkeloos. Het genereert, precies volgens de specificaties, een brief in HTML-bestandsopmaak. Deze kunt u vanuit uw browser naar de printer sturen.",
                        "Graag ontvangen wij per ommegaande betaling op het bij u bekende bankrekeningnummer."
                    };
                msg.Send();
            }
        }


        private static void PrintPromotional(Party sender, Party receipient)
        {
            using (var msg = letterFactory.CreateMessage("promotional"))
            {
                msg.Sender = sender;
                msg.Recipient = receipient;
                msg.Subject = "You won!";
                msg.Body = new[]
                    {
                        "Jij hebt meegedaan aan de prijsvraag van deze maand en gewonnen!",
                        "Op vertoon van deze brief mag jij samen met je ouders en een vriendje of vriendinnetje komen kijken hoe wij hier bij Hedgehog Industries ons werk doen.",
                        "Ook hebben we een leuke verrassiong voor je!",
                    };
                msg.Send();
            }
        }
    }
}