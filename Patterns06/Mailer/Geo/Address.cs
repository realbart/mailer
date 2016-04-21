using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Geo
{
    public class Address
    {
        public IEnumerable<string> AddressLines { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public IEnumerable<string> Format()
        {
            if (AddressLines != null) foreach (var line in AddressLines) yield return line;
            yield return $"{PostalCode}  {City}";
            yield return Country;
        }
    }
}
