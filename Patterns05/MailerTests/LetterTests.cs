using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mailer.Mails;
using System.IO;

namespace MailerTests
{
    [TestClass]
    public class LetterTests
    {
        [TestMethod]
        public void AllStringsIncluded()
        {
            using (var writer = new StringWriter())
            {
                new Letter
                {
                    Sender = new[] { "-1-", "-2-" },
                    Recipient = new[] { "-3-", "-4-" },
                    Subject = "-5-",
                    Body = new[] { "-6-", "-7-" },
                    Writer = writer
                }.Print();

                var txt = writer.GetStringBuilder().ToString();

                Assert.IsTrue(txt.Contains("-1-"), "-1-");
                Assert.IsTrue(txt.Contains("-2-"), "-2-");
                Assert.IsTrue(txt.Contains("-3-"), "-3-");
                Assert.IsTrue(txt.Contains("-4-"), "-4-");
                Assert.IsTrue(txt.Contains("-5-"), "-5-");
                Assert.IsTrue(txt.Contains("-6-"), "-6-");
                Assert.IsTrue(txt.Contains("-7-"), "-7-");

            }
        }
    }
}
