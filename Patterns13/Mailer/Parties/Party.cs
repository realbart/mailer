using Mailer.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Parties
{
    /// <summary>
    /// Either a sending, or a receiving party
    /// </summary>
    public abstract class Party
    {
        /// <summary>
        /// The name as it should appear in the address
        /// </summary>
        public string Name { get; set; }

        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EMail { get; set; }
    }
}
