using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Parties
{
    public class ReceivingParty: Party
    {
        /// <summary>
        /// Including the name
        /// </summary>
        /// <example>
        /// Salutation = "Dear Mrs. Doubtfire,"
        /// </example>
        public string Salutation { get; set; }
    }
}
