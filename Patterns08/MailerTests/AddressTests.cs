using Mailer.Geo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailerTests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void FormatDutchAddress()
        {
            var address = new Address(RegionFactory.Current["NL-ZH"], "Huis 1")
            {
                PostalCode = "3123 AA",
                City = "Schiedam",
            }.Format().ToArray();

            Assert.AreEqual(3, address.Length);
            Assert.AreEqual("Huis 1", address[0]);
            Assert.AreEqual("3123 AA  Schiedam (ZH)", address[1]);
            Assert.AreEqual("NEDERLAND", address[2]);
        }

        [TestMethod]
        public void FormatBritishAddress()
        {
            var address = new Address(RegionFactory.Current["GB-FLN"], "120 South Palafox Place")
            {
                PostalCode = "FL 32502",
                City = "Pensacola",
            }.Format().ToArray();

            Assert.AreEqual(4, address.Length);
            Assert.AreEqual("120 South Palafox Place", address[0]);
            Assert.AreEqual("PENSACOLA  FL 32502", address[1]);
            Assert.AreEqual("Flintshire", address[2]);
            Assert.AreEqual("Great Britain", address[3]);
        }


    }
}
