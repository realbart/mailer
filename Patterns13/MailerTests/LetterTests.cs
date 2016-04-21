using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mailer.Mails;
using System.IO;
using Mailer.Parties;
using Mailer.Geo;
using MailerTests.TestDoubles;

namespace MailerTests
{
    [TestClass]
    public class LetterTests
    {
        [TestMethod]
        public void LetterTest()
        {
            using (var writer = new StringWriter())
            using (var letter = new Letter(writer))
            {
                letter.Sender = new SendingParty { Closing = new[] { "-one-", "-two-", "-three-", "-four-" } };
                letter.Recipient = new ReceivingParty { Salutation = "-five-" };
                letter.Subject = "-six-";
                letter.Body = new[] { "-seven-", "-eight-" };

                letter.Send();

                var txt = writer.GetStringBuilder().ToString();
                Assert.IsTrue(txt.Contains("-one-"), "sender1 {0}", letter.GetType());
                Assert.IsTrue(txt.Contains("-two-"), "sender2 {0}", letter.GetType());
                Assert.IsTrue(txt.Contains("-three-"), "sender3 {0}", letter.GetType());
                Assert.IsTrue(txt.Contains("-four-"), "receiver1 {0}", letter.GetType());
                Assert.IsTrue(txt.Contains("-five-"), "receiver2 {0}", letter.GetType());
                Assert.IsTrue(txt.Contains("-six-"), "body1 {0}", letter.GetType());
                Assert.IsTrue(txt.Contains("-seven-"), "body2 {0}", letter.GetType());
            }
        }
        [TestMethod]
        public void AllStringsIncluded()
        {
            var region = RegionCollection.Current["NL-ZH"];
            using (var writer = new StringWriter())
            {
                var factory = new LetterFactory() { TextWriterCreator = () => writer };
                var letter = factory.CreateMessage("default");

                letter.Sender = new SendingParty { Name = "-1-", Address = new Address(region, new[] { "-1a-", "-1b-" }) { PostalCode = "-1c-", City = "-1d-" } };
                letter.Recipient = new ReceivingParty { Name = "-2-", Address = new Address(region, new[] { "-2a-", "-2b-" }) { PostalCode = "-2c-", City = "-2d-" } };
                letter.Subject = "-5-";
                letter.Body = new[] { "-6-", "-7-" };
                letter.Send();

                var txt = writer.GetStringBuilder().ToString();

                Assert.IsTrue(txt.Contains("-1-"), "-1-");
                Assert.IsTrue(txt.Contains("-1a-"), "-1a-");
                Assert.IsTrue(txt.Contains("-1b-"), "-1b-");
                Assert.IsTrue(txt.Contains("-1c-"), "-1c-");
                Assert.IsTrue(txt.Contains("-1d-"), "-1d-");
                Assert.IsTrue(txt.Contains("-2a-"), "-2a-");
                Assert.IsTrue(txt.Contains("-2b-"), "-2b-");
                Assert.IsTrue(txt.Contains("-2c-"), "-2c-");
                Assert.IsTrue(txt.Contains("-2d-"), "-2d-");
                Assert.IsTrue(txt.Contains("-5-"), "-5-");
                Assert.IsTrue(txt.Contains("-6-"), "-6-");
                Assert.IsTrue(txt.Contains("-7-"), "-7-");

            }
        }


        [TestMethod]
        public void EMailTest()
        {
            using (var sender = new EmailSenderSpy())
            using (var letter = new Email(sender))
            {
                letter.Sender = new SendingParty { Name = "-one-", EMail="-t@w.o-", Closing = new[] {"-three-", "-four-" } };
                letter.Recipient = new ReceivingParty { Name="-five-", EMail="-s@i.x-", Salutation = "-seven-" };
                letter.Subject = "-eight-";
                letter.Body = new[] { "-nine-", "-ten-" };
                letter.Send();

                Assert.AreEqual("-one-", sender.MailMessage.Sender.DisplayName);
                Assert.AreEqual("-t@w.o-", sender.MailMessage.Sender.Address);
                // etc
            }
        }
    }
}
