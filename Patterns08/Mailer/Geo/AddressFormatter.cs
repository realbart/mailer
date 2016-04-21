using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Geo
{
    public class AddressWriter : IAddressFormatter
    {
        private AddressWriter() { }

        public readonly static IAddressFormatter Default = new AddressWriter();

        public IEnumerable<string> Format(Address address)
        {
            foreach (var line in address.AddressLines.EmptyIfNull())
            {
                yield return line;
            }
            yield return $"{address.City?.ToUpper()}  {address.PostalCode}";
            foreach (var subdivision in address?.Region.GetRegions())
            {
                yield return subdivision.Name;
            }
        }
    }
}
