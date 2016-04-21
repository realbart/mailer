using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mailer.Mails;
using System.IO;
using Mailer.Parties;
using Mailer.Geo;

namespace MailerTests
{
    [TestClass]
    public class LetterTests
    {
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
    }
}
