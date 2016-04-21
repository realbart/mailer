using Mailer.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Parties
{
    /// <summary>
    /// Sender or Recipient
    /// </summary>
    public class Party
    {
        public string Name { get; set; }

        public Address Address { get; set; }

        public IEnumerable<string> Format()
        {
            yield return Name;
            if (Address != null) foreach (var line in Address.Format()) yield return line;
        }
    }
}
