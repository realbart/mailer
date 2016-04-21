using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Parties
{
    public class SendingParty: Party
    {
        /// <summary>
        /// The ending of the letter.
        /// </summary>
        /// <example>
        /// Closing = new [] {"Yours truly,", "Mr. Doubtfire"};
        /// </example>
        public IEnumerable<string> Closing { get; set; }
    }
}
