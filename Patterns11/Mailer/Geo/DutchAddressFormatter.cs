using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Geo
{
    public class DutchAddressFormatter : IAddressFormatter
    {
        public IEnumerable<string> Format(Address address)
        {
            foreach (var line in address.AddressLines.EmptyIfNull()) yield return line;
            var pc = string.IsNullOrWhiteSpace(address.PostalCode) ? "" : (address.PostalCode + "  ");
            var regions = address.Region.GetRegions();
            var subdivisions = regions.Reverse().Skip(1).Reverse();
            var subdivision = subdivisions.Any()
                    ? $" ({string.Join(", ", subdivisions.Select(d => d.ShortName))})"
                    : "";
            var country = regions.Last().Name.ToUpper();
            yield return $"{pc}{address.City}{subdivision}";
            yield return country;
        }
    }
}
