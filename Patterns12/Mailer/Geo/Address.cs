using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Geo
{
    public class Address
    {
        public Address(Region region, params string[] addressLines) : this(region, (IEnumerable<string>)addressLines) { }

        public Address(Region region, IEnumerable<string> addressLines)
        {
            if (region == null) throw new ArgumentNullException(nameof(region));
            AddressLines = addressLines;
            Region = region;
        }

        /// <summary>
        /// At least one line, including name, postal code and city, excluding name and country
        /// </summary>
        public IEnumerable<string> AddressLines { get; }
        public Region Region { get; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public IEnumerable<string> Format()
        {
            return Region.Format(this);
        }
    }
}
